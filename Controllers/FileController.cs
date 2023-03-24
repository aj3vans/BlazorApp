using BlazorApp.Connections;
using BlazorApp.Interfaces;
using BlazorApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BlazorApp.Controllers
{
    [Route("File")]
    public class FileController : Controller
    {
        private readonly IDbConn _conn;

        public FileController(IDbConn conn)
        {
            _conn = conn;
        }
        //--

        [HttpGet]
        [Route("Upload")]
        public async Task<IActionResult> Upload()
        {
            var viewModel = new FileUploadVm();

            var conn = await _conn.Connect();

            return View(viewModel);
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(FileUploadVm viewModel)
        {           
            //try
            //{
                
            //}
            //catch (IOException) { throw; }
            //catch (Exception) { throw; }

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
