using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;

namespace BussinesLogic
{
    public class EmpleadoBL
    {
        private static EmpleadoBL _instance;

        public static EmpleadoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmpleadoBL();
                return _instance;
            }
        }

        public List<Empleado> SelectAll()
        {
            List<Empleado> result = null;
            try
            {
                result = EmpleadoDAL.Instance.SelectAll();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }


        public Empleado SelectById(int id)
        {
            Empleado result = null;
            try
            {
                result = EmpleadoDAL.Instance.SelectById(id);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }

        public bool Insert(Empleado entity)
        {
            bool result = false;
            try
            {
                if (!VerificarNombre(entity.Nombre))
                    result = EmpleadoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Empleado entity)
        {
            bool result = false;
            try
            {
                if (!VerificarNombre(entity.Nombre))
                    result = EmpleadoDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = MarcaDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool VerificarNombre(string criteria)
        {
            bool result = false;
            try
            {
                var query = MarcaDAL.Instance.SelectAll()
                    .Where(x => x.Nombre.ToLower().Equals(criteria.ToLower())).ToList();

                result = query.Count > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

    }
}
