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
    public class CategoriaDAL : Connection
    {
        private static CategoriaDAL _instance;

        public static CategoriaDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CategoriaDAL();
                return _instance;
            }
        }

        public bool Insert(Categoria entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCategoriaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;                  
                }
            }

            return result;
        }

        public List<Categoria> SelectAll()
        {
            List<Categoria> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCategoriaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Categoria>();
                            while (dr.Read())
                            {
                                Categoria entity = new Categoria()
                                {
                                    CategoriaId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
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

        public Categoria SelectById(int id)
        {
            Categoria result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCategoriaSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoriaId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Categoria()
                                {
                                    CategoriaId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Descripcion = dr.GetString(2)
                                };
                            }
                        }
                    }


                }
            }

            return result;
        }

        public bool Update(Categoria entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCategoriaUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
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
                using (SqlCommand cmd = new SqlCommand("spCategoriaDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoriaId", id);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}