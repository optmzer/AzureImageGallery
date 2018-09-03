using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureImageGallery.Data;
using AzureImageGallery.Data.Models;
using AzureImageGallery.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        public GalleryController(IImage imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var imageList = _imageService.GetAll();

            var model = new GalleryIndexModel()
            {
                Images = imageList,
                SearchQuery = ""
            };
            return View(model);
        }
    }
}