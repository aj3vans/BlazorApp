using BlazorApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BlazorApp.Controllers
{
    [Route("File")]
    public class FileController : Controller
    {
        //private readonly IFileService _uploadService;

        //public FileController(IFileService uploadService)
        //{
        //    _uploadService = uploadService;
        //}
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
        public IActionResult Upload(FileUploadVm viewModel)
        {
            //Getting file meta data
            var fileName = Path.GetFileName(viewModel.MyFiles.FileName);
            var contentType = viewModel.MyFiles.ContentType;

            return Content(fileName);
        }

        /*
         * download 
         * 
         try
            {
                var file =  dbContextClass.FileDetails.Where(x => x.ID == Id).FirstOrDefaultAsync();

                var content = new System.IO.MemoryStream(file.Result.FileData);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Result.FileName);

                await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
         */
    }
}
