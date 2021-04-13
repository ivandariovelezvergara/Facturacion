using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoFacturacion.Facturacion
{
   public  class DEliminarFactura
    {
        private readonly IConfiguration configuration;
        public DEliminarFactura(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.Respuesta respuesta(Entities.Facturacion.ELiminarFactura eliminar)
        {
            SqlParameter[] param = new SqlParameter[]

            {

               new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@ID",
                    Value = eliminar.IdFactura
                }
                
           };
            DSQL db = new DSQL(configuration);
            DataTable dt = db.ProcedureTable("DBO.ELIMINARFACTURA", true, param);
            if (dt.Rows.Count > 0)
            {
                Entities.Facturacion.Respuesta resultado = new Entities.Facturacion.Respuesta
                {
                    Codigo = Convert.ToInt32(dt.Rows[0][0]),
                    Mensaje = dt.Rows[0][1].ToString()
                };
                return resultado;
            }
            else
            {
                return null;
            }

        }
    }
}
