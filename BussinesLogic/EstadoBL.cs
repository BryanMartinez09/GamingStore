using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class EstadoBL
    {
        private static EstadoBL _instance;

        public static EstadoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EstadoBL();
                return _instance;
            }
        }

        public List<Estado> SelectAll()
        {
            List<Estado> result = null;
            try
            {
                result = EstadoDAL.Instance.SelectAll();
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
    }
}
