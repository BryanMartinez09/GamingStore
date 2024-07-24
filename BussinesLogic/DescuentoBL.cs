using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class DescuentoBL
    {
        public List<Descuento> SelectAll()
        {
            List<Descuento> result = null;

            try
            {
                result = DescuentoDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
