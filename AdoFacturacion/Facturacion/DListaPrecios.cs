using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AdoFacturacion.Facturacion
{
    public class DListaPrecios
    {
        private readonly IConfiguration configuration;
        public DListaPrecios(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public List<Entities.Facturacion.ListaPrecios> RespuestaLista()
        {
            List<Entities.Facturacion.ListaPrecios> lista;
            DSQL db = new DSQL(configuration);
            DataTable dt = db.ProcedureTable("DBO.LISTAPRECIOS", false);
            if (dt.Rows.Count > 0)
            {
                lista = new List<Entities.Facturacion.ListaPrecios>();
                foreach (DataRow row in dt.Rows)
                {
                    Entities.Facturacion.ListaPrecios respuesta = new Entities.Facturacion.ListaPrecios
                    {

                        Producto = row[0].ToString(),
                        Descripcion = row[1].ToString(),
                        Disponible = Convert.ToBoolean(dt.Rows[0][2]),
                        PrecioVenta = Convert.ToInt32(dt.Rows[0][3]),
                        PrecioCompra = Convert.ToInt32(dt.Rows[0][4])
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
