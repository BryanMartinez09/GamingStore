using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria() { }

        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
