using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AdoFacturacion.Facturacion
{
   public  class DListaCompras
    {
        private readonly IConfiguration configuration;
        public DListaCompras(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public List<Entities.Facturacion.ListaCompras> RespuestaLista()
        {
            List<Entities.Facturacion.ListaCompras> lista;
            DSQL db = new DSQL(configuration);
            DataTable dt = db.ProcedureTable("DBO.LISTACOMPRAS", false);
            if (dt.Rows.Count > 0)
            {
                lista = new List<Entities.Facturacion.ListaCompras>();
                foreach (DataRow row in dt.Rows)
                {
                    Entities.Facturacion.ListaCompras respuesta = new Entities.Facturacion.ListaCompras
                    {
                        
                        Nombres = row[0].ToString(),
                        FechaCompra = row[1].ToString(),
                        Producto = row[2].ToString()
                    };
                    lista.Add(respuesta);
                }
                return lista;
            }
            else
            {
                return null;
            }

        }
    }
}
