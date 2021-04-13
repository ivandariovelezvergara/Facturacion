using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoFacturacion
{
    class DSQL
    {
        private readonly string _connectionString;
        SqlConnection connection;
        public DSQL(IConfiguration _configuration)
        {
            connection = new SqlConnection();
            _connectionString = _configuration.GetConnectionString("Facturacion");
            connection.ConnectionString = _connectionString;
        }

        public DataTable ProcedureTable(string procedure, bool parametersHave, SqlParameter[] parameters = null)
        {
            SqlCommand storedProcCommand = new SqlCommand(procedure, connection);
            SqlDataAdapter sda = new SqlDataAdapter(storedProcCommand);
            DataTable dt = new DataTable();
            storedProcCommand.CommandType = CommandType.StoredProcedure;

            if (parametersHave == true)
            {
                storedProcCommand.Parameters.AddRange(parameters);
            }
            storedProcCommand.CommandTimeout = 300;
            connection.Open();
            sda.Fill(dt);
            connection.Close();
            return dt;
        }
    }
}
