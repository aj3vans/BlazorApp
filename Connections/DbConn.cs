using BlazorApp.Interfaces;
using Microsoft.Data.SqlClient;

namespace BlazorApp.Connections
{
    public class DbConn : IDbConn
    {
        private readonly IConfiguration _configuration;

        public DbConn(IConfiguration configuration)
        {
            _configuration = configuration;
        }   
        //--

        public async Task<SqlConnection> Connect(string connectionString = "DefaultConnection")
        {
			try
			{
                var connString = _configuration.GetConnectionString(connectionString);  
                var conn = new SqlConnection(connString);
                await conn.OpenAsync();

                return conn;
			}
            catch (SqlException) { throw; }
            catch (Exception) { throw; }
        }
    }
}
