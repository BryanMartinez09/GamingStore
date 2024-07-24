using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class ProductoBL
    {

        private static ProductoBL _instance;

        public static ProductoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProductoBL();

                return _instance;
            }
        }


        public List<Producto> SelectAll()
        {
            List<Producto> result = null;

            try
            {
                result = ProductoDAL.Instance.SelectAll();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
        public int Insert(Producto entity)
        {
            int result = 0;
            try
            {
                //if (!VerificarMarca(entity.Nombre))
                    result = ProductoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
