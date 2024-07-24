using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class TipoPago
    {
        public int TipoPagoId { get; set; }
        public string Pago { get; set; }

        public TipoPago() { }

        public TipoPago(string pago)
        {
            Pago = pago;
        }
    }
}
