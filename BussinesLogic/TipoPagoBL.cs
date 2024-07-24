using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class TipoPagoBL
    {
        private static TipoPagoDAL instance;
        public static TipoPagoDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TipoPagoDAL();
                return instance;
            }
        }
        public List<TipoPago> SelectAll()
        {
            List<TipoPago> result = null;

            try
            {
                result = TipoPagoDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
