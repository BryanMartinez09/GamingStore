using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class DetVenta
    {
        public int DeVentaId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public DetVenta() { }

        public DetVenta(int ventaId, int productoId, decimal precio, int cantidad, decimal subtotal)
        {
            VentaId = ventaId;
            ProductoId = productoId;
            Precio = precio;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }
    }
}
