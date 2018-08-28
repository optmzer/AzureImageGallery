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
        public IEnumerable<GalleryImages> Images { get; set; } 

        /**
         * Stores users input
         */
        public string SearchQuery { get; set; }

    }
}
