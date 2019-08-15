using shopping.data.Core;
using System;
using System.Collections.Generic;

namespace shopping.data.Models
{
    public partial class Productos: ModelBase<int>
    {
        public Productos()
        {
            FacturaDetalle = new HashSet<FacturaDetalle>();
            ProductosActivo = new HashSet<ProductosActivo>();
        }

        public int IdCategoriaProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? Disponible { get; set; }
        public int? Orders { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual CategoriaProductos IdCategoriaProductoNavigation { get; set; }
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
        public virtual ICollection<ProductosActivo> ProductosActivo { get; set; }
    }
}
