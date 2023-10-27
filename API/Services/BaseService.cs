using System.Data.SqlClient;

namespace API.Services {
    public class BaseService {
        private static string connectionString()
        {
            return "Server=tcp:projeto-danilo-server.database.windows.net,1433;Initial Catalog=projeto-danilo-db;Persist Security Info=False;User ID=rodrigo;Password=#RODehopoder97;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public static SqlConnection getConnection(){
            var sqlConn = new SqlConnection(connectionString());
            sqlConn.Open();            

            return sqlConn;
        }
    }
}
