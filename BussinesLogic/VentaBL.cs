using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class VentaBL
    {
        public static object Instance { get; set; }

        public List<Venta> SelectAll()
        {
            List<Venta> result = null;

            try
            {
                result = VentaDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
