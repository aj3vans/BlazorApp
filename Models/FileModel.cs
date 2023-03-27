namespace BlazorApp.Models
{
    public class FileModel
    {
        public int FileId { get; set; }

        public string? FileName { get; set; }

        public string? FileExtension { get; set; }

        public string? FileType { get; set; }

        public long FileSize { get; set; }

        public byte[]? FileBinary { get; set; }
    }
}
