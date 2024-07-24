using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Descripcion { get; set; }
        public decimal TotalPagar { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int TipoPagoId { get; set; }

        public Venta() { }

        public Venta(DateTime fechaVenta, string descripcion, decimal totalPagar, int empleadoId, int clienteId, int usuarioId, int tipoPagoId)
        {
            FechaVenta = fechaVenta;
            Descripcion = descripcion;
            TotalPagar = totalPagar;
            EmpleadoId = empleadoId;
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            TipoPagoId = tipoPagoId;
        }
    }
}
