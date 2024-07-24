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
    public class CompraDAL:Connection
    {
        private static CompraDAL instance;
        public static CompraDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CompraDAL();
                return instance;
            }
        }

        public bool Insert(Compra entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCompraInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaCompra", entity.FechaCompra);
                    cmd.Parameters.AddWithValue("@TotalCompra", entity.TotalCompra);
                    cmd.Parameters.AddWithValue("@ProveedorId", entity.ProveedorId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<Compra> SelectAll()
        {
            List<Compra> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCompraSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Compra>();

                            while (dr.Read())
                            {
                                Compra entity = new Compra();
                                entity.CompraId = dr.GetInt32(0);
                                entity.FechaCompra = dr.GetDateTime(1);
                                entity.TotalCompra = dr.GetDecimal(2);
                                entity.ProveedorId = dr.GetInt32(3);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Compra SelectById(int id)
        {
            Compra result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCompraSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompraId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Compra();

                            while (dr.Read())
                            {
                                result.CompraId = dr.GetInt32(0);
                                result.FechaCompra = dr.GetDateTime(1);
                                result.TotalCompra = dr.GetDecimal(2);
                                result.ProveedorId = dr.GetInt32(3);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Compra entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCompraUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompraId", entity.CompraId);
                    cmd.Parameters.AddWithValue("@FechaCompra", entity.FechaCompra);
                    cmd.Parameters.AddWithValue("@TotalCompra", entity.TotalCompra);
                    cmd.Parameters.AddWithValue("@ProveedorId", entity.ProveedorId);

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
                using (SqlCommand cmd = new SqlCommand("spCompraDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompraId", id);

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
