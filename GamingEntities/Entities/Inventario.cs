using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Inventario
    {
        public int InventarioId { get; set; }
        public int Stock { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int ProductoId { get; set; }

        public Inventario() { }

        public Inventario(int stock, DateTime fechaRegistro, int productoId)
        {
            Stock = stock;
            FechaRegistro = fechaRegistro;
            ProductoId = productoId;
        }
    }
}
