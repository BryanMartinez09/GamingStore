using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class ProveedorBL
    {


        private static ProveedorBL _instance;

        public static ProveedorBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProveedorBL();

                return _instance;
            }
        }

        public List<Proveedor> SelectAll()
        {
            List<Proveedor> result = null;

            try
            {
                result = ProveedorDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
