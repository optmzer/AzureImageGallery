using Microsoft.EntityFrameworkCore;
using System;

namespace AzureImageGallery.Data
{
    public class AzureImageGalleryDbContext: DbContext
    {
        /**
         * Constructor
         */ 
        public AzureImageGalleryDbContext(DbContextOptions options): base(options)
        {

        }
        // Creates new table GalleryImages
        public DbSet<GalleryImage> GalleryImages { get; set; }
    }
}
