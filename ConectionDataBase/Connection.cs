using System.Data.SqlClient;

namespace ConnectionDataBase
{
    public class Connection
    {
        readonly SqlConnection con = new SqlConnection();

        public Connection()
        {
            con.ConnectionString = @"Data Source=DESKTOP-61L2M0C\SQLEXPRESS;integrated security=SSPI;initial Catalog=TesteV2";
            con.Open();
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            return con;
        }

        public SqlConnection Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return con;
        }
    }
}   