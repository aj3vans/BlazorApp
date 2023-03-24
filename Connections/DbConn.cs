using BlazorApp.Interfaces;
using Microsoft.Data.SqlClient;

namespace BlazorApp.Connections
{
    public class DbConn : IDbConn
    {
        public async Task<SqlConnection> Connect(string connectionString = "DefaultConnection")
        {
			try
			{
                using SqlConnection conn = new SqlConnection(connectionString);
                await conn.OpenAsync();

                return conn;
			}
            catch (SqlException) { throw; }
            catch (Exception) { throw; }
        }
    }
}
