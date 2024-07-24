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
    public class MarcaBL
    {
        private static MarcaBL _instance;

        public static MarcaBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MarcaBL();
                return _instance;
            }
        }

        public List<Marca> SelectAll()
        {
            List<Marca> result = null;
            try
            {
                result = MarcaDAL.Instance.SelectAll();
            }
            catch (SqlException ex)
            {
               
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message);
            }

            return result;
        }


        public Marca SelectById(int id)
        {
            Marca result = null;
            try
            {
                result = MarcaDAL.Instance.SelectById(id);
            }
            catch (SqlException ex)
            {
                //Que hacer
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }

        public bool Insert(Marca entity)
        {
            bool result = false;
            try
            {
                if (!VerificarMarca(entity.Nombre))
                    result = MarcaDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Marca entity)
        {
            bool result = false;
            try
            {
                if (!VerificarMarca(entity.Nombre))
                    result = MarcaDAL.Instance.Update(entity);
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

        public bool VerificarMarca(string criteria)
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