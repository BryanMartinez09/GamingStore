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
    public class InventarioDAL:Connection
    {
        private static InventarioDAL instance;
        public static InventarioDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new InventarioDAL();
                return instance;
            }
        }

        public bool Insert(Inventario entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spInventarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Stock", entity.Stock);
                    cmd.Parameters.AddWithValue("@FechaRegistro", entity.FechaRegistro);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<Inventario> SelectAll()
        {
            List<Inventario> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spInventarioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Inventario>();

                            while (dr.Read())
                            {
                                Inventario entity = new Inventario();
                                entity.InventarioId = dr.GetInt32(0);
                                entity.Stock = dr.GetInt32(1);
                                entity.FechaRegistro = dr.GetDateTime(2);
                                entity.ProductoId = dr.GetInt32(3);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Inventario SelectById(int id)
        {
            Inventario result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spInventarioSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventarioId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Inventario();

                            while (dr.Read())
                            {
                                result.InventarioId = dr.GetInt32(0);
                                result.Stock = dr.GetInt32(1);
                                result.FechaRegistro = dr.GetDateTime(2);
                                result.ProductoId = dr.GetInt32(3);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Inventario entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spInventarioUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventarioId", entity.InventarioId);
                    cmd.Parameters.AddWithValue("@Stock", entity.Stock);
                    cmd.Parameters.AddWithValue("@FechaRegistro", entity.FechaRegistro);
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
                using (SqlCommand cmd = new SqlCommand("spInventarioDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventarioId", id);

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
