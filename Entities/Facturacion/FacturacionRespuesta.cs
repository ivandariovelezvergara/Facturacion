using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Facturacion
{
    public class FacturacionRespuesta
    {
        public int Factura { get; set; }
        public string Cliente { get; set; }
        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Venta { get; set; }
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
    }
}
