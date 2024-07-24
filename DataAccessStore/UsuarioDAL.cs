using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessStore
{
    public class UsuarioDAL:Connection
    {
        private static UsuarioDAL instance;
        public static UsuarioDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UsuarioDAL();
                return instance;
            }
        }

        public bool Insert(Usuario entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spUsuarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Password", entity.Password);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<Usuario> SelectAll()
        {
            List<Usuario> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spUsuarioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Usuario>();

                            while (dr.Read())
                            {
                                Usuario entity = new Usuario();
                                entity.UsuarioId = dr.GetInt32(0);
                                entity.Nombre = dr.GetString(1);
                                entity.Password = dr.GetString(2);
                                entity.EmpleadoId = dr.GetInt32(3);
                                entity.RolId = dr.GetInt32(4);
                                entity.EstadoId = dr.GetInt32(5);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Usuario SelectById(int id)
        {
            Usuario result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spUsuarioSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Usuario();

                            while (dr.Read())
                            {
                                result.UsuarioId = dr.GetInt32(0);
                                result.Nombre = dr.GetString(1);
                                result.Password = dr.GetString(2);
                                result.EmpleadoId = dr.GetInt32(3);
                                result.RolId = dr.GetInt32(4);
                                result.EstadoId = dr.GetInt32(5);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Usuario entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spUsuarioUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Password", entity.Password);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
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
                using (SqlCommand cmd = new SqlCommand("spUsuarioDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
