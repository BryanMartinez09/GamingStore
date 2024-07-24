using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class RolBL
    {

        private static RolDAL instance;
        public static RolDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new RolDAL();
                return instance;
            }
        }

        public List<Rol> SelectAll()
        {
            List<Rol> result = null;

            try
            {
                result = RolDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
