using Microsoft.Data.SqlClient;

namespace BlazorApp.Interfaces
{
    public interface IDbConn
    {
        Task<SqlConnection> Connect(string connectionString = "DefaultConnection");
    }
}
