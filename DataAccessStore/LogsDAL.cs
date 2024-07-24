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
    public class LogsDAL:Connection
    {
        private static LogsDAL instance;
        public static LogsDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LogsDAL();
                return instance;
            }
        }

        public bool Insert(Logs entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spLogsInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                    cmd.Parameters.AddWithValue("@Accion", entity.Accion);
                    cmd.Parameters.AddWithValue("@Tabla", entity.Tabla);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<Logs> SelectAll()
        {
            List<Logs> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spLogsSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Logs>();

                            while (dr.Read())
                            {
                                Logs entity = new Logs();
                                entity.Fecha = dr.GetDateTime(0);
                                entity.Accion = dr.GetString(1);
                                entity.Tabla = dr.GetString(2);
                                entity.Descripcion = dr.GetString(3);
                                entity.UsuarioId = dr.GetInt32(4);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Logs SelectById(int id)
        {
            Logs result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spLogsSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdLogs", id);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Logs();

                            while (dr.Read())
                            {
                                result.Fecha = dr.GetDateTime(0);
                                result.Accion = dr.GetString(1);
                                result.Tabla = dr.GetString(2);
                                result.Descripcion = dr.GetString(3);
                                result.UsuarioId = dr.GetInt32(4);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Logs entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("spLogsUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdLogs", entity);
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                    cmd.Parameters.AddWithValue("@Accion", entity.Accion);
                    cmd.Parameters.AddWithValue("@Tabla", entity.Tabla);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);

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
                using (SqlCommand cmd = new SqlCommand("spLogsDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdLogs", id);

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
