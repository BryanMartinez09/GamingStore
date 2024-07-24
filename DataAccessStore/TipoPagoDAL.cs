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
    public class TipoPagoDAL : Connection
    {
        private static TipoPagoDAL instance;
        public static TipoPagoDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TipoPagoDAL();
                return instance;
            }
        }

        public bool Insert(TipoPago entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spTipoPagoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Pago", entity.Pago);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<TipoPago> SelectAll()
        {
            List<TipoPago> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spTipoPagoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<TipoPago>();

                            while (dr.Read())
                            {
                                TipoPago entity = new TipoPago();
                                entity.TipoPagoId = dr.GetInt32(0);
                                entity.Pago = dr.GetString(1);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public TipoPago SelectById(int id)
        {
            TipoPago result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spTipoPagoSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoPagoId", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new TipoPago();

                            while (dr.Read())
                            {
                                result.TipoPagoId = dr.GetInt32(0);
                                result.Pago = dr.GetString(1);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(TipoPago entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spTipoPagoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoPagoId", entity.TipoPagoId);
                    cmd.Parameters.AddWithValue("@Pago", entity.Pago);

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
                using (SqlCommand cmd = new SqlCommand("spTipoPagoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoPagoId", id);

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
