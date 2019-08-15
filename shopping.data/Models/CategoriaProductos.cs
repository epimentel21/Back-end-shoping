using shopping.data.Core;
using System;
using System.Collections.Generic;

namespace shopping.data.Models
{
    public partial class CategoriaProductos:ModelBase<int>
    {
        public CategoriaProductos()
        {
            Productos = new HashSet<Productos>();
        }

        
        public string Descripcion { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
