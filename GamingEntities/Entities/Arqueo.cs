using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Arqueo
    {
        public int ArqueoId { get; set; }
        public DateTime Fecha{ get; set; }
        public float MontoInicial { get; set; }
        public float MontoFinal { get; set; }
        public string NumCaja { get; set; }
        public int UsuarioId { get; set; }
        public string AutorizaMontoVenta { get; set; }

        public Arqueo() { }

        public Arqueo(DateTime fecha, float montoInicial, float montoFinal, string numCaja, int usuarioId, string autorizaMontoVenta)
        {
            Fecha = fecha;
            MontoInicial = montoInicial;
            MontoFinal = montoFinal;
            NumCaja = numCaja;
            UsuarioId = usuarioId;
            AutorizaMontoVenta = autorizaMontoVenta;
        }
    }
}
