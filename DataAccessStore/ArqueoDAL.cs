using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace DataAccessStore
{
    public class ArqueoDAL : Connection
    {
        private static ArqueoDAL _instance;

        public static ArqueoDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ArqueoDAL();
                return _instance;
            }
        }

        public bool Insert(Arqueo entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spMarcaInsert", conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
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

        public List<Arqueo> SelectAll()
        {
            List<Arqueo> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spArqueoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Arqueo>();
                            while (dr.Read())
                            {
                                Arqueo entity = new Arqueo()
                                {
                                    ArqueoId = dr.GetInt32(0),
                                    Fecha = dr.GetDateTime(1),
                                    MontoInicial = dr.GetFloat(2),
                                    MontoFinal = dr.GetFloat(3),
                                    NumCaja = dr.GetString(4),
                                    UsuarioId = dr.GetInt32(5),
                                    AutorizaMontoVenta = dr.GetString(6)
                                };
                                result.Add(entity);
                            }
                        }
                    }

                }
            }

            return result;

        }

        public Arqueo SelectById(int id)
        {
            Arqueo result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spArqueoSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArqueoId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Arqueo()
                                {
                                    ArqueoId = dr.GetInt32(0),
                                    Fecha = dr.GetDateTime(1),
                                    MontoInicial = dr.GetFloat(2),
                                    MontoFinal = dr.GetFloat(3),
                                    NumCaja = dr.GetString(4),
                                    UsuarioId = dr.GetInt32(5),
                                    AutorizaMontoVenta = dr.GetString(6),

                                };
                            }
                        }
                    }
                }
            }

            return result;
        }

        public bool Update(Arqueo entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spArqueoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArqueoId", entity.ArqueoId);
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
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
                using (SqlCommand cmd = new SqlCommand("spArqueoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArqueoId", id);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
