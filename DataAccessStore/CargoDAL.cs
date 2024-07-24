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
    public class CargoDAL : Connection
    {
        private static CargoDAL _instance;

        public static CargoDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CargoDAL();
                return _instance;
            }
        }

        public bool Insert(Cargo entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCargoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0; // Retorna el numero de registros affectados                   
                }
            }

            return result;
        }

        public List<Cargo> SelectAll()
        {
            List<Cargo> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCargoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Cargo>();
                            while (dr.Read())
                            {
                                Cargo entity = new Cargo()
                                {
                                    CargoId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Descripcion = dr.GetString(2)
                                };
                                result.Add(entity);
                            }
                        }
                    }

                }
            }

            return result;

        }

        public Cargo SelectById(int id)
        {
            Cargo result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCargoSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CargoId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Cargo()
                                {
                                    CargoId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Descripcion = dr.GetString(2)
                                };
                            }
                        }
                    }


                }
            }

            return result;
        }

        public bool Update(Cargo entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spCargoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CargoId", entity.CargoId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);

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
                using (SqlCommand cmd = new SqlCommand("spCargoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CargoId", id);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}