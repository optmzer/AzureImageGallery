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
                    Url = "https://images.pexels.com/photos/454880/pexels-photo-454880.jpeg?auto=compress&cs=tinysrgb&h=650&w=940",
                    Created = DateTime.Now,
                    Tags = hikingImageTags
                },

                new GalleryImage()
                {
                    Title = "On The Trail",
                    Url = "https://images.pexels.com/photos/33109/fall-autumn-red-season.jpg?auto=compress&cs=tinysrgb&h=650&w=940",
                    Created = DateTime.Now,
                    Tags = hikingImageTags
                },

                new GalleryImage()
                {
                    Title = "Downtown",
                    Url = "https://images.pexels.com/photos/302769/pexels-photo-302769.jpeg?cs=srgb&dl=architecture-building-business-302769.jpg&fm=jpg",
                    Created = DateTime.Now,
                    Tags = cityImageTags
                }
            };

            var model = new GalleryIndexModel()
            {
                Images = imageList,
                SearchQuery = ""
            };
            return View(model);
        }
    }
}