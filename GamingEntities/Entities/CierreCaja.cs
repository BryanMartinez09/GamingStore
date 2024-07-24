using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class CierreCaja
    {
        public int IdCierreCaja { get; set; }
        public DateTime FechaInicio { get; set; }
        public float MontoInicial { get; set; }
        public float MontoFinal { get; set; }
        public string NumCaja { get; set; }
        public int UsuarioId { get; set; }
        public string AutorizaMontoVenta { get; set; }

        public CierreCaja() { }

        public CierreCaja(DateTime fechaInicio, float montoInicial, float montoFinal, string numCaja, int usuarioId, string autorizaMontoVenta)
        {
            FechaInicio = fechaInicio;
            MontoInicial = montoInicial;
            MontoFinal = montoFinal;
            NumCaja = numCaja;
            UsuarioId = usuarioId;
            AutorizaMontoVenta = autorizaMontoVenta;
        }
    }
}
