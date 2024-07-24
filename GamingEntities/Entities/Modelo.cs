using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Modelo
    {
        public int ModeloId { get; set; }
        public string Model { get; set; }
        public string Descripcion { get; set; }

        public Modelo() { }

        public Modelo(string model, string descripcion)
        {
            Model = model;
            Descripcion = descripcion;
        }
    }
}
