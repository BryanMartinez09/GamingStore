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
    public class CierreCajaDAL:Connection
    {
        private static CierreCajaDAL instance;
        public static CierreCajaDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CierreCajaDAL();
                return instance;
            }
        }

        public bool Insert(CierreCaja entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCierreCajaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", entity.FechaInicio);
                    cmd.Parameters.AddWithValue("@MontoInicial", entity.MontoInicial);
                    cmd.Parameters.AddWithValue("@MontoFinal", entity.MontoFinal);
                    cmd.Parameters.AddWithValue("@NumCaja", entity.NumCaja);
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);
                    cmd.Parameters.AddWithValue("@AutorizaMontoVenta", entity.AutorizaMontoVenta);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<CierreCaja> SelectAll()
        {
            List<CierreCaja> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCierreCajaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<CierreCaja>();

                            while (dr.Read())
                            {
                                CierreCaja entity = new CierreCaja();
                                entity.IdCierreCaja = dr.GetInt32(0);
                                entity.FechaInicio = dr.GetDateTime(1);
                                entity.MontoInicial = (float)dr.GetDouble(2);
                                entity.MontoFinal = (float)dr.GetDouble(3);
                                entity.NumCaja = dr.GetString(4);
                                entity.UsuarioId = dr.GetInt32(5);
                                entity.AutorizaMontoVenta = dr.GetString(6);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public CierreCaja SelectById(int id)
        {
            CierreCaja result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCierreCajaSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCierreCaja", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new CierreCaja();

                            while (dr.Read())
                            {
                                result.IdCierreCaja = dr.GetInt32(0);
                                result.FechaInicio = dr.GetDateTime(1);
                                result.MontoInicial = (float)dr.GetDouble(2);
                                result.MontoFinal = (float)dr.GetDouble(3);
                                result.NumCaja = dr.GetString(4);
                                result.UsuarioId = dr.GetInt32(5);
                                result.AutorizaMontoVenta = dr.GetString(6);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(CierreCaja entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCierreCajaUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCierreCaja", entity.IdCierreCaja);
                    cmd.Parameters.AddWithValue("@FechaInicio", entity.FechaInicio);
                    cmd.Parameters.AddWithValue("@MontoInicial", entity.MontoInicial);
                    cmd.Parameters.AddWithValue("@MontoFinal", entity.MontoFinal);
                    cmd.Parameters.AddWithValue("@NumCaja", entity.NumCaja);
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);
                    cmd.Parameters.AddWithValue("@AutorizaMontoVenta", entity.AutorizaMontoVenta);

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
                using (SqlCommand cmd = new SqlCommand("spCierreCajaDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCierreCaja", id);

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
