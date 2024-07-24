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
    public class ArqueoBL
    {
        private static ArqueoBL _instance;

        public static ArqueoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ArqueoBL();
                return _instance;
            }
        }

        public List<Arqueo> SelectAll()
        {
            List<Arqueo> result = null;
            try
            {
                result = ArqueoDAL.Instance.SelectAll();
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


        public Arqueo SelectById(int id)
        {
            Arqueo result = null;
            try
            {
                result = ArqueoDAL.Instance.SelectById(id);
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

        public bool Insert(Arqueo entity)
        {
            bool result = false;
            try
            {
                if (!VerificarArqueo(entity.NumCaja))
                    result = ArqueoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Arqueo entity)
        {
            bool result = false;
            try
            {
                if (!VerificarArqueo(entity.NumCaja))
                    result = ArqueoDAL.Instance.Update(entity);
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
                result = ArqueoDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
        
        public bool VerificarArqueo(string criteria)
        {
            bool result = false;
            try
            {
                var query = ArqueoDAL.Instance.SelectAll()
                    .Where(x => x.NumCaja.ToLower().Equals(criteria.ToLower())).ToList();

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