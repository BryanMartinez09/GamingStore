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
    public class VentaDAL : Connection
    {
        private static VentaDAL instance;
        public static VentaDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new VentaDAL();
                return instance;
            }
        }

        public bool Insert(Venta entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spVentaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaVenta", entity.FechaVenta);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@TotalPagar", entity.TotalPagar);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);
                    cmd.Parameters.AddWithValue("@TipoPagoId", entity.TipoPagoId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<Venta> SelectAll()
        {
            List<Venta> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spVentaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Venta>();

                            while (dr.Read())
                            {
                                Venta entity = new Venta();
                                entity.VentaId = dr.GetInt32(0);
                                entity.FechaVenta = dr.GetDateTime(1);
                                entity.Descripcion = dr.GetString(2);
                                entity.TotalPagar = dr.GetDecimal(3);
                                entity.EmpleadoId = dr.GetInt32(4);
                                entity.ClienteId = dr.GetInt32(5);
                                entity.UsuarioId = dr.GetInt32(6);
                                entity.TipoPagoId = dr.GetInt32(7);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Venta SelectById(int id)
        {
            Venta result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spVentaSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VentaId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Venta();

                            while (dr.Read())
                            {
                                result.VentaId = dr.GetInt32(0);
                                result.FechaVenta = dr.GetDateTime(1);
                                result.Descripcion = dr.GetString(2);
                                result.TotalPagar = dr.GetDecimal(3);
                                result.EmpleadoId = dr.GetInt32(4);
                                result.ClienteId = dr.GetInt32(5);
                                result.UsuarioId = dr.GetInt32(6);
                                result.TipoPagoId = dr.GetInt32(7);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Venta entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spVentaUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VentaId", entity.VentaId);
                    cmd.Parameters.AddWithValue("@FechaVenta", entity.FechaVenta);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@TotalPagar", entity.TotalPagar);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);
                    cmd.Parameters.AddWithValue("@TipoPagoId", entity.TipoPagoId);

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
                using (SqlCommand cmd = new SqlCommand("spVentaDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VentaId", id);

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
