using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int EmpleadoId { get; set; }
        public int RolId { get; set; }
        public int EstadoId { get; set; }

        public Usuario() { }

        public Usuario(string nombre, string password, int empleadoId, int rolId, int estadoId)
        {
            Nombre = nombre;
            Password = password;
            EmpleadoId = empleadoId;
            RolId = rolId;
            EstadoId = estadoId;
        }
    }
}
