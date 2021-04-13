using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AdoFacturacion.Facturacion
{
    public class DListaProducto
    {
        private readonly IConfiguration configuration;
        public DListaProducto(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public List<Entities.Facturacion.ListaProducto> RespuestaLista()
        {
            List<Entities.Facturacion.ListaProducto> lista;
            DSQL db = new DSQL(configuration);
            DataTable dt = db.ProcedureTable("DBO.LISTAPRODUCTOS", false);
            if (dt.Rows.Count > 0)
            {
                lista = new List<Entities.Facturacion.ListaProducto>();
                foreach (DataRow row in dt.Rows)
                {
                    Entities.Facturacion.ListaProducto respuesta = new Entities.Facturacion.ListaProducto
                    {

                        Nombre = row[0].ToString(),
                        Descripcion = row[1].ToString(),
                        Cantidad = row[2].ToString()
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
