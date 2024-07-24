using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEntities.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }

        public Producto() { }

        public Producto(string nombre, string codigo, string descripcion, decimal precioVenta, int proveedorId, int categoriaId, int marcaId, int modeloId)
        {
            Nombre = nombre;
            Codigo = codigo;
            Descripcion = descripcion;
            PrecioVenta = precioVenta;
            ProveedorId = proveedorId;
            CategoriaId = categoriaId;
            MarcaId = marcaId;
            ModeloId = modeloId;
        }
    }
}
