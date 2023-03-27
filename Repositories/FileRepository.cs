using BlazorApp.Interfaces;
using BlazorApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorApp.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IDbConn _conn;

        public FileRepository(IDbConn conn)
        {
            _conn = conn;
        }
        //--

        public async Task<FileModel> GetById(int fileId)
        {
            var command = new SqlCommand("File-GetById");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FileId", fileId);

            return await GetFile(command);
        }

        private async Task<FileModel> GetFile(SqlCommand command)
        {
            var file = new FileModel();

            try
            {
                using (var conn = await _conn.Connect())
                {
                    command.Connection = conn;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            file.FileId = reader.GetInt32("FileId");
                            file.FileName = reader.GetString("FileName");
                            file.FileBinary = (byte[])reader["FileBinary"];
                        }
                    }
                }

                return file;
            }
            catch (SqlException) { throw; }
            catch (Exception) { throw; }
        }

        public async Task<FileModel> Save(FileModel file)
        {
            try
            {
                using (var conn = await _conn.Connect())
                {
                    var command = new SqlCommand("Files-Save", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FileId", file.FileId);
                    command.Parameters.AddWithValue("@FileName", file.FileName);
                    command.Parameters.AddWithValue("@FileBinary", file.FileBinary);

                    file.FileId = Convert.ToInt32(await command.ExecuteScalarAsync());

                    return file;
                }
            }
            catch (SqlException) { throw; }
            catch (Exception) { throw; }            
        }
    }
}
