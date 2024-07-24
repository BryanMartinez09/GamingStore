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
    public class ClienteDAL:Connection
    {
        private static ClienteDAL instance;
        public static ClienteDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ClienteDAL();
                return instance;
            }

        }

        public bool Insert(Cliente entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spClienteInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", entity.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<Cliente> SelectAll()
        {
            List<Cliente> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spClienteSelectAll", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Cliente>();

                            while (dr.Read())
                            {
                                Cliente entity = new Cliente();
                                entity.ClienteId = dr.GetInt32(0);
                                entity.Nombre = dr.GetString(1);
                                entity.Apellido = dr.GetString(2);
                                entity.Telefono = dr.GetString(3);
                                entity.Correo = dr.GetString(4);

                                result.Add(entity);

                            }
                        }
                    }

                }
            }
            return result;
        }

        public Cliente SelectById(int id)
        {
            Cliente result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spClienteSelectById", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {

                        if (dr != null)
                        {
                            result = new Cliente();

                            while (dr.Read())
                            {
                                result.ClienteId = dr.GetInt32(0);
                                result.Nombre = dr.GetString(1);
                                result.Apellido = dr.GetString(2);
                                result.Telefono = dr.GetString(3);
                                result.Correo = dr.GetString(4);
                            }
                        }
                    }

                }
            }
            return result;
        }

        public bool Update(Cliente entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spClienteUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", entity.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);

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
                using (SqlCommand cmd = new SqlCommand("spClienteDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", id);

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
