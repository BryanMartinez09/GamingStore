using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class DetCompraBL
    {
        public List<DetCompra> SelectAll()
        {
            List<DetCompra> result = null;

            try
            {
                result = DetCompraDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }


    }
}
