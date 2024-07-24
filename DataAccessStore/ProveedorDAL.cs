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
    public class ProveedorDAL : Connection
    {
        private static ProveedorDAL instance;
        public static ProveedorDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProveedorDAL();
                return instance;
            }
        }

        public bool Insert(Proveedor entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spProveedorInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", entity.CorreoElectronico);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<Proveedor> SelectAll()
        {
            List<Proveedor> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spProveedorSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Proveedor>();

                            while (dr.Read())
                            {
                                Proveedor entity = new Proveedor();
                                entity.ProveedorId = dr.GetInt32(0);
                                entity.Nombre = dr.GetString(1);
                                entity.Direccion = dr.GetString(2);
                                entity.Telefono = dr.GetString(3);
                                entity.CorreoElectronico = dr.GetString(4);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Proveedor SelectById(int id)
        {
            Proveedor result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spProveedorSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProveedorId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Proveedor();

                            while (dr.Read())
                            {
                                result.ProveedorId = dr.GetInt32(0);
                                result.Nombre = dr.GetString(1);
                                result.Direccion = dr.GetString(2);
                                result.Telefono = dr.GetString(3);
                                result.CorreoElectronico = dr.GetString(4);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Proveedor entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spProveedorUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProveedorId", entity.ProveedorId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", entity.CorreoElectronico);

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
                using (SqlCommand cmd = new SqlCommand("spProveedorDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProveedorId", id);

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
