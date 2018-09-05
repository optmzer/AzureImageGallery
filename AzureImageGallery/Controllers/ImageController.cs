using AzureImageGallery.Data;
using AzureImageGallery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AzureImageGallery.Controllers
{
    public class ImageController : Controller
    {
        private IConfiguration _config;
        private IImage _imageService;

        private string AzureConnectionString { get; }

        public ImageController(IConfiguration config, IImage imageService)
        {
            _config = config;
            _imageService = imageService;

            AzureConnectionString = _config["AZURE_STOREAGE_CONNECTION_STRING"];
        }

        public IActionResult Upload()
        {
            var model = new UploadImageModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewImage(IFormFile file, string title, string tags)
        {
            // name of the storage container = images
            var container = _imageService.GetBlobContainer(AzureConnectionString, "images");

            var contDispResHeader = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var fileName = contDispResHeader.FileName.Trim('"');// Trim quotes as it comes as "FileName"

            // Get a reference to a block blob
            var blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            await _imageService.SetImage(title, tags, blockBlob.Uri);

            return RedirectToAction("Index", "Gallery");
        }
    }
}