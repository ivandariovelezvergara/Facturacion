using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoFacturacion.Facturacion
{
    public class DConsultaFactura
    {
        private readonly IConfiguration configuration;
        public DConsultaFactura(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.FacturacionRespuesta Respuesta(Entities.Facturacion.Facturacion facturacion)
        {
            SqlParameter[] param = new SqlParameter[]

          {
               new SqlParameter
                {
                    DbType = DbType.Int64,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDFACTURA",
                    Value = facturacion.Factura
                }
           };
            DSQL db = new DSQL(configuration);
            DataTable dt = db.ProcedureTable("DBO.CONSULTAFACTURA", true, param);
            if (dt.Rows.Count > 0)
            {

                Entities.Facturacion.FacturacionRespuesta resultado = new Entities.Facturacion.FacturacionRespuesta 
                {
                    Factura = Convert.ToInt32(dt.Rows[0][0]),
                    Cliente = dt.Rows[0][1].ToString(),
                    Fecha = dt.Rows[0][2].ToString(),
                    Nombre = dt.Rows[0][3].ToString(),
                    Descripcion = dt.Rows[0][4].ToString(),
                    Venta = dt.Rows[0][5].ToString(),
                };
                resultado.Codigo = 1;
                resultado.Mensaje = "OK";
                return resultado;
            }
            else
            {
                return new Entities.Facturacion.FacturacionRespuesta
                {
                    Codigo = Convert.ToInt32(dt.Rows[0][0]),
                    Mensaje = dt.Rows[0][1].ToString()
                };
            }
        }
    }
}
