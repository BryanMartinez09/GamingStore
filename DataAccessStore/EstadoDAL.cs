using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingEntities;

namespace DataAccessStore
{
    public class EstadoDAL : Connection
    {
        private static EstadoDAL _instance;

        public static EstadoDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EstadoDAL();
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
                    cmd.Parameters.AddWithValue("EstadoId", entity.EstadoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0; // Retorna el numero de registros affectados                   
                }
            }

            return result;
        }

        public List<Estado> SelectAll()
        {
            List<Estado> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spEstadoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Estado>();
                            while (dr.Read())
                            {
                                Estado entity = new Estado()
                                {
                                    EstadoId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1)
                                };
                                result.Add(entity);
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

        //public List<Producto> SelectProductoByMarcaId(int id)
        //{

        //}

    }
}
