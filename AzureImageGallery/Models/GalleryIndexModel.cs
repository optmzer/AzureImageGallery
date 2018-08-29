using AzureImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureImageGallery.Models
{
    public class GalleryIndexModel
    {
        /**
         * For images data
         */
        public IEnumerable<GalleryImage> Images { get; set; } 

        /**
         * Stores users input
         */
        public string SearchQuery { get; set; }

    }
}
