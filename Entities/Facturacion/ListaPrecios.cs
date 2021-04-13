using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Facturacion
{
    public class ListaPrecios
    {
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public Boolean Disponible { get; set; }
        public Decimal PrecioVenta { get; set; }
        public Decimal PrecioCompra { get; set; }
    }
}
