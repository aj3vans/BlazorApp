using BlazorApp.Models;

namespace BlazorApp.Interfaces
{
    public interface IFileRepository
    {
        Task<FileModel> GetById(int fileId);

        Task<FileModel> Save(FileModel file);
    }
}
