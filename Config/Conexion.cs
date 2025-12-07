using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace _02_CRUD.Config
{
    public class conexion
    {
          private readonly string cadena_conexion =
           "Server=LAPTOP-RJI9MC23;Database=cuarto25m26;User Id=sa;Password=123;" +
            "TrustServerCertificate=True;";

        public SqlConnection obtenerConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(cadena_conexion);
            return sqlConnection;
        }

    }


}