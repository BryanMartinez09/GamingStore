using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Cargo
    {
        public int CargoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Cargo() { }

        public Cargo(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

    }
}
