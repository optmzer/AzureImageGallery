using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureImageGallery.Data;
using AzureImageGallery.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureImageGallery.Services
{
    /**
     * This service will interact with a search box on the page.
     */
    public class ImageService : IImage
    {
        private readonly AzureImageGalleryDbContext _context;

        public ImageService(AzureImageGalleryDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<GalleryImage> GetAll()
        {
            return _context.GalleryImages.Include(img => img.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return GetAll().Where(img => img.Id == id).First();
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll()
                .Where(image => image.Tags.Any(t => t.Description == tag));
        }

        public CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            return blobClient.GetContainerReference(containerName);
        }

        /**
         * Creates a reference to the image in SQL database
         */
        public async Task SetImage(string title, string tags, Uri uri)
        {
            //TODO: make sure to init tags if they are null
            if (tags == null)
            {
                tags = "none";
            }
            var image = new GalleryImage
            {
                Title = title,
                Tags = ParseTags(tags),
                Url = uri.AbsoluteUri,
                Created = DateTime.Now
            };

            _context.Add(image);
            await _context.SaveChangesAsync();
        }

        public List<ImageTag> ParseTags(string tags)
        {
            /* This is the same as return below
            var imageTags = new List<ImageTag>();
            var tagList = tags.Split(",").ToList();

            foreach (var tag in tagList)
            {
                imageTags.Add(new ImageTag
                {
                    Description = tag
                });
            }

            return imageTags;
            */

            return tags.Split(",").Select(tag => new ImageTag
            {
                Description = tag
            }).ToList();
        }
    }
}
