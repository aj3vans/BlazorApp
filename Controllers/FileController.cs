using BlazorApp.Interfaces;
using BlazorApp.Models;
using BlazorApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BlazorApp.Controllers
{
    [Route("File")]
    public class FileController : Controller
    {
        private readonly IFileRepository _repo;

        public FileController(IFileRepository repo)
        {
            _repo = repo;
        }
        //--

        [HttpGet]
        [Route("Upload")]
        public IActionResult Upload()
        {
            var viewModel = new FileUploadVm();

            return View(viewModel);
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(FileUploadVm viewModel)
        {
            int maxSize = 10485760; //-- 10 Megabyte 

            try
            {
                if (viewModel.MyFiles.Count > 0)
                {
                    foreach (var myFile in viewModel.MyFiles)
                    {
                        // validate file size
                        if (myFile.Length >= maxSize)
                        {
                            ModelState.AddModelError("File too large", $"{myFile.FileName} exceeds the maximum file size allowed for uploads.");
                            return View(viewModel);
                        }

                        var file = new FileModel();
                        file.FileName = Path.GetFileNameWithoutExtension(myFile.FileName);
                        file.FileExtension = Path.GetExtension(myFile.FileName);
                        file.FileType = myFile.ContentType;
                        file.FileSize = myFile.Length;

                        using (var stream = new MemoryStream())
                        {
                            await myFile.CopyToAsync(stream);
                            file.FileBinary = stream.ToArray();
                        }

                        file.FileId = await _repo.Save(file);
                    }
                    return Content($"You have successfully uploaded {viewModel.MyFiles.Count}.");
                }
                return Content("No file where uploaded.");
            }
            catch (IOException) { throw; }
            catch (Exception) { throw; }
        }

        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> Download(int id)
        {
            var file = await _repo.GetById(id);

            if (file.FileBinary != null && file.FileType != null) 
            {
                return File(file.FileBinary, file.FileType, "Document_Title.pdf");
            }

            return Content("File not found.");
        }       
    }
}
