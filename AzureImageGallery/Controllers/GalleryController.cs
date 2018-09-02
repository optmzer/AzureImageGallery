using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureImageGallery.Data.Models;
using AzureImageGallery.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var hikingImageTags = new List<ImageTag>();
            var cityImageTags = new List<ImageTag>();

            var tag00 = new ImageTag()
            {
                Description = "Adventure",
                Id = 0
            };

            var tag01 = new ImageTag()
            {
                Description = "Urban",
                Id = 1
            };

            var tag02 = new ImageTag()
            {
                Description = "Petropavlovsk-Kamchatsy",
                Id = 2
            };

            hikingImageTags.Add(tag00);
            cityImageTags.AddRange(new List<ImageTag>{ tag00, tag01});

            var imageList = new List<GalleryImage>()
            {
                new GalleryImage()
                {
                    Title = "Hiking Trip",
                    Url = "https://www.pexels.com/photo/daylight-environment-forest-idyllic-459225/",
                    Created = DateTime.Now,
                    Tags = hikingImageTags
                },

                new GalleryImage()
                {
                    Title = "On The Trail",
                    Url = "https://www.pexels.com/photo/conifer-daylight-environment-evergreen-454880/",
                    Created = DateTime.Now,
                    Tags = hikingImageTags
                },

                new GalleryImage()
                {
                    Title = "Downtown",
                    Url = "https://www.pexels.com/photo/view-of-high-rise-buildings-during-day-time-302769/",
                    Created = DateTime.Now,
                    Tags = cityImageTags
                }
            };

            var model = new GalleryIndexModel()
            {
                Images = imageList
            };
            return View(model);
        }
    }
}