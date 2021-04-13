using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Facturacion
{
    public class CrearProducto
    {
        public string Nombre { get; set; }
        public string  Descripcion { get; set; }
        public bool Disponible { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; } 

    }
}
