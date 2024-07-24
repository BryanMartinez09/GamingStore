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
    public class DescuentoDAL : Connection
    {
        private static DescuentoDAL instance;
        public static DescuentoDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DescuentoDAL();
                return instance;
            }
        }

        public bool Insert(Descuento entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDescuentoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", entity.Codigo);
                    cmd.Parameters.AddWithValue("@PorcentajeDescuento", entity.PorcentajeDescuento);
                    cmd.Parameters.AddWithValue("@FechaInicio", entity.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinal", entity.FechaFinal);
                    cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<Descuento> SelectAll()
        {
            List<Descuento> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDescuentoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Descuento>();

                            while (dr.Read())
                            {
                                Descuento entity = new Descuento();
                                entity.DescuentoId = dr.GetInt32(0);
                                entity.Codigo = dr.GetString(1);
                                entity.PorcentajeDescuento = dr.GetDecimal(2);
                                entity.FechaInicio = dr.GetDateTime(3);
                                entity.FechaFinal = dr.GetDateTime(4);
                                entity.CategoriaId = dr.GetInt32(5);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Descuento SelectById(int id)
        {
            Descuento result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDescuentoSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DescuentoId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Descuento();

                            while (dr.Read())
                            {
                                result.DescuentoId = dr.GetInt32(0);
                                result.Codigo = dr.GetString(1);
                                result.PorcentajeDescuento = dr.GetDecimal(2);
                                result.FechaInicio = dr.GetDateTime(3);
                                result.FechaFinal = dr.GetDateTime(4);
                                result.CategoriaId = dr.GetInt32(5);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Descuento entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spDescuentoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DescuentoId", entity.DescuentoId);
                    cmd.Parameters.AddWithValue("@Codigo", entity.Codigo);
                    cmd.Parameters.AddWithValue("@PorcentajeDescuento", entity.PorcentajeDescuento);
                    cmd.Parameters.AddWithValue("@FechaInicio", entity.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinal", entity.FechaFinal);
                    cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);

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
                using (SqlCommand cmd = new SqlCommand("spDescuentoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DescuentoId", id);

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
