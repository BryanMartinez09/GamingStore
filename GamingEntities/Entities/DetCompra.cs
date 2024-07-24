using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class DetCompra
    {
        public int DetCompraId { get; set; }
        public decimal SubTotal { get; set; }
        public int ProductoId { get; set; }

        public DetCompra() { }

        public DetCompra(decimal subTotal, int productoId)
        {
            SubTotal = subTotal;
            ProductoId = productoId;
        }
    }
}
