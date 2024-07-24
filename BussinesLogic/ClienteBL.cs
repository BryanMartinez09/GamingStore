using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class ClienteBL
    {
        private static ClienteDAL instance;
        public static ClienteDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ClienteDAL();
                return instance;
            }
        }
        public List<Cliente> SelectAll()
        {
            List<Cliente> result = null;

            try
            {
                result = ClienteDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
