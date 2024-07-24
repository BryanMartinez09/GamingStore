using DataAccessStore;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class UsuarioBL
    {



        private static UsuarioDAL instance;
        public static UsuarioDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UsuarioDAL();
                return instance;
            }
        }

        public List<Usuario> SelectAll()
        {
            List<Usuario> result = null;

            try
            {
                result = UsuarioDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
