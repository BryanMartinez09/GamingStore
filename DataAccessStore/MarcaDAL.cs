using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace DataAccessStore
{
    public class MarcaDAL : Connection
    {
        private static MarcaDAL _instance;

        public static MarcaDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MarcaDAL();
                return _instance;
            }
        }

        public bool Insert(Marca entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spMarcaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0; // Retorna el numero de registros affectados                   
                }
            }

            return result;
        }

        public List<Marca> SelectAll()
        {
            List<Marca> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spMarcaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Marca>();
                            while (dr.Read())
                            {
                                Marca entity = new Marca()
                                {
                                    MarcaId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    EstadoId = dr.GetInt32(2)
                                };
                                result.Add(entity);
                            }
                        }
                    }

                }
            }

            return result;

        }

        public Marca SelectById(int id)
        {
            Marca result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spMarcaSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MarcaId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Marca()
                                {
                                    MarcaId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    EstadoId = dr.GetInt32(2)
                                };
                            }
                        }
                    }


                }
            }

            return result;
        }
       

        public bool Update(Marca entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spMarcaUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MarcaId", entity.MarcaId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spMarcaDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MarcaId", id);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
