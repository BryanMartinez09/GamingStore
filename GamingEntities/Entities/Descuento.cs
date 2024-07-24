using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Descuento
    {
        public int DescuentoId { get; set; }
        public string Codigo { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int CategoriaId { get; set; }

        public Descuento() { }

        public Descuento(string codigo, decimal porcentajeDescuento, DateTime fechaInicio, DateTime fechaFinal, int categoriaId)
        {
            Codigo = codigo;
            PorcentajeDescuento = porcentajeDescuento;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            CategoriaId = categoriaId;
        }
    }
}
