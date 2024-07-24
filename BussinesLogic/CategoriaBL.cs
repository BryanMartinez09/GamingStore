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
    public class CategoriaBL
    {
        private static CategoriaBL _instance;

        public static CategoriaBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CategoriaBL();
                return _instance;
            }
        }

        public List<Categoria> SelectAll()
        {
            List<Categoria> result = null;
            try
            {
                result = CategoriaDAL.Instance.SelectAll();
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


        public Categoria SelectById(int id)
        {
            Categoria result = null;
            try
            {
                result = CategoriaDAL.Instance.SelectById(id);
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

        public bool Insert(Categoria entity)
        {
            bool result = false;
            try
            {
                if (!VerificarCategoria(entity.Nombre))
                    result = CategoriaDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Categoria entity)
        {
            bool result = false;
            try
            {
                if (!VerificarCategoria(entity.Nombre))
                    result = CategoriaDAL.Instance.Update(entity);
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
                result = CategoriaDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool VerificarCategoria(string criteria)
        {
            bool result = false;
            try
            {
                var query = CategoriaDAL.Instance.SelectAll()
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