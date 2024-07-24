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
    public class EmpleadoDAL : Connection
    {
        private static EmpleadoDAL _instance;

        public static EmpleadoDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmpleadoDAL();
                return _instance;
            }
        }

        public bool Insert(Empleado entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spEmpleadoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", entity.Apellido);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Genero", entity.Genero);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", entity.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@CargoId", entity.CargoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0; // Retorna el numero de registros affectados                   
                }
            }

            return result;
        }

        public List<Empleado> SelectAll()
        {
            List<Empleado> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spEmpleadoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Empleado>();
                            while (dr.Read())
                            {
                                Empleado entity = new Empleado()
                                {
                                    EmpleadoId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Apellido = dr.GetString(2),
                                    DUI = dr.GetString(3),
                                    Genero = dr.GetString(4),
                                    Telefono = dr.GetString(5),
                                    CorreoElectronico = dr.GetString(6),
                                    CargoId = dr.GetInt32(7)
                                };
                                result.Add(entity);
                            }
                        }
                    }

                }
            }

            return result;

        }

        public Empleado SelectById(int id)
        {
            Empleado result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spEmpleadoSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Empleado()
                                {
                                    EmpleadoId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Apellido = dr.GetString(2),
                                    DUI = dr.GetString(3),
                                    Genero = dr.GetString(4),
                                    Telefono = dr.GetString(5),
                                    CorreoElectronico = dr.GetString(6),
                                    CargoId = dr.GetInt32(7)
                                };
                            }
                        }
                    }


                }
            }

            return result;
        }

        public bool Update(Empleado entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spEmpleadoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", entity.Apellido);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Genero", entity.Genero);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", entity.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@CargoId", entity.CargoId);

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
                using (SqlCommand cmd = new SqlCommand("spEmpleadoaDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", id);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}

