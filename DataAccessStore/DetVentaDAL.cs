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
    public class DetVentaDAL:Connection
    {
        private static DetVentaDAL instance;
        public static DetVentaDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DetVentaDAL();
                return instance;
            }
        }

        public bool Insert(DetVenta entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDetVentaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VentaId", entity.VentaId);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@Precio", entity.Precio);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@Subtotal", entity.Subtotal);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<DetVenta> SelectAll()
        {
            List<DetVenta> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDetVentaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<DetVenta>();

                            while (dr.Read())
                            {
                                DetVenta entity = new DetVenta();
                                entity.DeVentaId = dr.GetInt32(0);
                                entity.VentaId = dr.GetInt32(1);
                                entity.ProductoId = dr.GetInt32(2);
                                entity.Precio = dr.GetDecimal(3);
                                entity.Cantidad = dr.GetInt32(4);
                                entity.Subtotal = dr.GetDecimal(5);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public DetVenta SelectById(int id)
        {
            DetVenta result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDetVentaSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeVentaId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new DetVenta();

                            while (dr.Read())
                            {
                                result.DeVentaId = dr.GetInt32(0);
                                result.VentaId = dr.GetInt32(1);
                                result.ProductoId = dr.GetInt32(2);
                                result.Precio = dr.GetDecimal(3);
                                result.Cantidad = dr.GetInt32(4);
                                result.Subtotal = dr.GetDecimal(5);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(DetVenta entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDetVentaUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeVentaId", entity.DeVentaId);
                    cmd.Parameters.AddWithValue("@VentaId", entity.VentaId);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@Precio", entity.Precio);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@Subtotal", entity.Subtotal);

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
                using (SqlCommand cmd = new SqlCommand("spDetVentaDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeVentaId", id);

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
