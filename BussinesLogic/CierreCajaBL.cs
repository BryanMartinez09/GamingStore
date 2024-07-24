using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class CierreCajaBL
    {
        public List<CierreCaja> SelectAll()
        {
            List<CierreCaja> result = null;

            try
            {
                result = CierreCajaDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
