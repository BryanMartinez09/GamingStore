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
    public class ModeloBL
    {
        private static ModeloBL _instance;

        public static ModeloBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ModeloBL();
                return _instance;
            }
        }

        public List<Modelo> SelectAll()
        {
            List<Modelo> result = null;
            try
            {
                result = ModeloDAL.Instance.SelectAll();
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


        public Modelo SelectById(int id)
        {
            Modelo result = null;
            try
            {
                result = ModeloDAL.Instance.SelectById(id);
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

        public bool Insert(Modelo entity)
        {
            bool result = false;
            try
            {
                if (!VerificarModelo(entity.Model))
                    result = ModeloDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Modelo entity)
        {
            bool result = false;
            try
            {
                if (!VerificarModelo(entity.Model))
                    result = ModeloDAL.Instance.Update(entity);
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
                result = ModeloDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool VerificarModelo(string criteria)
        {
            bool result = false;
            try
            {
                var query = ModeloDAL.Instance.SelectAll()
                    .Where(x => x.Model.ToLower().Equals(criteria.ToLower())).ToList();

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