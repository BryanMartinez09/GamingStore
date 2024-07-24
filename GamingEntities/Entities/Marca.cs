using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; }
        public int EstadoId { get; set; }

        public  Marca (int marcaId, string nombre, int estadoId)
        {
            MarcaId = marcaId;
            Nombre = nombre;
            EstadoId = estadoId;

        }

        public Marca()
        {
        }
    }
}
