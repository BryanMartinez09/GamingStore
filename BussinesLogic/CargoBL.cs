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
    public class CargoBL
    {
        private static CargoBL _instance;

        public static CargoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CargoBL();
                return _instance;
            }
        }

        public List<Cargo> SelectAll()
        {
            List<Cargo> result = null;
            try
            {
                result = CargoDAL.Instance.SelectAll();
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


        public Cargo SelectById(int id)
        {
            Cargo result = null;
            try
            {
                result = CargoDAL.Instance.SelectById(id);
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

        public bool Insert(Cargo entity)
        {
            bool result = false;
            try
            {
                if (!VerificarCargo(entity.Nombre))
                    result = CargoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Cargo entity)
        {
            bool result = false;
            try
            {
                if (!VerificarCargo(entity.Nombre))
                    result = CargoDAL.Instance.Update(entity);
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
                result = CargoDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool VerificarCargo(string criteria)
        {
            bool result = false;
            try
            {
                var query = CargoDAL.Instance.SelectAll()
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
