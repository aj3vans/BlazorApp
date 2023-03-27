namespace BlazorApp.Models
{
    public class FileModel
    {
        public int FileId { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileBinary { get; set; }
    }
}
