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
    public class DetCompraDAL:Connection
    {
        private static DetCompraDAL instance;
        public static DetCompraDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DetCompraDAL();
                return instance;
            }
        }

        public bool Insert(DetCompra entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDetCompraInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubTotal", entity.SubTotal);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<DetCompra> SelectAll()
        {
            List<DetCompra> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDetCompraSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<DetCompra>();

                            while (dr.Read())
                            {
                                DetCompra entity = new DetCompra();
                                entity.DetCompraId = dr.GetInt32(0);
                                entity.SubTotal = dr.GetDecimal(1);
                                entity.ProductoId = dr.GetInt32(2);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public DetCompra SelectById(int id)
        {
            DetCompra result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDetCompraSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DetCompraId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new DetCompra();

                            while (dr.Read())
                            {
                                result.DetCompraId = dr.GetInt32(0);
                                result.SubTotal = dr.GetDecimal(1);
                                result.ProductoId = dr.GetInt32(2);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(DetCompra entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDetCompraUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DetCompraId", entity.DetCompraId);
                    cmd.Parameters.AddWithValue("@SubTotal", entity.SubTotal);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);

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
                using (SqlCommand cmd = new SqlCommand("spDetCompraDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DetCompraId", id);

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
