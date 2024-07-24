using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal TotalCompra { get; set; }
        public int ProveedorId { get; set; }

        public Compra() { }

        public Compra(DateTime fechaCompra, decimal totalCompra, int proveedorId)
        {
            FechaCompra = fechaCompra;
            TotalCompra = totalCompra;
            ProveedorId = proveedorId;
        }
    }
}
