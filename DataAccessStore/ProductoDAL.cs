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
    public class ProductoDAL : Connection
    {
        private static ProductoDAL instance;
        public static ProductoDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductoDAL();
                return instance;
            }
        }

        public int Insert(Producto entity)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ProductoInsert", conn))  // El nombre del procedimiento almacenado debe coincidir con el nombre en la base de datos
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioVenta", entity.PrecioVenta);
                    cmd.Parameters.AddWithValue("@ProveedorId", entity.ProveedorId);
                    cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);
                    cmd.Parameters.AddWithValue("@MarcaId", entity.MarcaId);
                    cmd.Parameters.AddWithValue("@ModeloId", entity.ModeloId);

                    
                    SqlParameter outputParam = new SqlParameter("@Identity", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    
                    result = outputParam.Value != DBNull.Value ? Convert.ToInt32(outputParam.Value) : 0;
                }
            }

            return result;
        }


        public List<Producto> SelectAll()
        {
            List<Producto> result = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spProductoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Producto entity = new Producto
                            {
                                ProductoId = dr.GetInt32(dr.GetOrdinal("ProductoId")),
                                Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                                Descripcion = dr.GetString(dr.GetOrdinal("Descripcion")),
                                PrecioVenta = dr.GetDecimal(dr.GetOrdinal("PrecioVenta")),
                                ProveedorId = dr.GetInt32(dr.GetOrdinal("ProveedorId")),
                                CategoriaId = dr.GetInt32(dr.GetOrdinal("CategoriaId")),
                                MarcaId = dr.GetInt32(dr.GetOrdinal("MarcaId")),
                                ModeloId = dr.GetInt32(dr.GetOrdinal("ModeloId"))
                            };

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }


        public Producto SelectById(int id)
        {
            Producto result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spProductoSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Producto();

                            while (dr.Read())
                            {
                                result.ProductoId = dr.GetInt32(0);
                                result.Nombre = dr.GetString(1);
                                result.Codigo = dr.GetString(2);
                                result.Descripcion = dr.GetString(3);
                                result.PrecioVenta = dr.GetDecimal(4);
                                result.ProveedorId = dr.GetInt32(5);
                                result.CategoriaId = dr.GetInt32(6);
                                result.MarcaId = dr.GetInt32(7);
                                result.ModeloId = dr.GetInt32(8);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Producto entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spProductoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Codigo", entity.Codigo);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioVenta", entity.PrecioVenta);
                    cmd.Parameters.AddWithValue("@ProveedorId", entity.ProveedorId);
                    cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);
                    cmd.Parameters.AddWithValue("@MarcaId", entity.MarcaId);
                    cmd.Parameters.AddWithValue("@ModeloId", entity.ModeloId);

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
                using (SqlCommand cmd = new SqlCommand("spProductoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", id);

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
