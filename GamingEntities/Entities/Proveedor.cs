using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public Proveedor() { }

        public Proveedor(string nombre, string direccion, string telefono, string correoElectronico)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
        }
    }
}
