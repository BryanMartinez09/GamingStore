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
    public class ModeloDAL : Connection
    {
        private static ModeloDAL _instance;

        public static ModeloDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ModeloDAL();
                return _instance;
            }
        }

        public bool Insert(Modelo   entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spModeloInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Modelo", entity.Model);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0; // Retorna el numero de registros affectados                   
                }
            }

            return result;
        }

        public List<Modelo> SelectAll()
        {
            List<Modelo> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spModeloSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Modelo>();
                            while (dr.Read())
                            {
                                Modelo entity = new Modelo()
                                {
                                    ModeloId = dr.GetInt32(0),
                                    Model = dr.GetString(1),
                                    Descripcion = dr.GetString(2)
                                };
                                result.Add(entity);
                            }
                        }
                    }

                }
            }

            return result;

        }

        public Modelo SelectById(int id)
        {
            Modelo result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spModeloSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ModeloId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Modelo()
                                {
                                    ModeloId = dr.GetInt32(0),
                                    Model = dr.GetString(1),
                                    Descripcion = dr.GetString(2)
                                };
                            }
                        }
                    }


                }
            }

            return result;
        }

        public bool Update(Modelo entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spModeloUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ModeloId", entity.ModeloId);
                    cmd.Parameters.AddWithValue("@Model", entity.Model);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);

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
                using (SqlCommand cmd = new SqlCommand("spModeloDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ModeloId", id);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
