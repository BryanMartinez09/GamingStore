using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Logs
    {
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }

        public Logs() { }

        public Logs(DateTime fecha, string accion, string tabla, string descripcion, int usuarioId)
        {
            Fecha = fecha;
            Accion = accion;
            Tabla = tabla;
            Descripcion = descripcion;
            UsuarioId = usuarioId;
        }
    }
}
