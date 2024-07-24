using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DUI { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int CargoId { get; set; }

        public Empleado() { }


        public Empleado (int empleadoId, string nombre, string apellido, string dUI, string genero, string telefono, string correoElectronico, int cargoId)
        {
            EmpleadoId = empleadoId;
            Nombre = nombre;
            Apellido = apellido;
            DUI = dUI;
            Genero = genero;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            CargoId = cargoId;
        }
    }
}
