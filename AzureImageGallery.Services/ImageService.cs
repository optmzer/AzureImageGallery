using System;
using System.Collections.Generic;
using System.Linq;
using AzureImageGallery.Data;
using AzureImageGallery.Data.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
