using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccessStore
{
    public class Connection
    {
        protected string _cadena = 
            ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
    }
}
