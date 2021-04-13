using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Facturacion
{
    public class ValorTotal
    {
        public int Productos { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Decimal Total { get; set; }
    }
}
