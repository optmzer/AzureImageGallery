using System;
using System.Collections.Generic;
using System.Text;

namespace AzureImageGallery.Data.Models
{
    public class GalleryImage
    {
        public int Id { get; set; }

        public string Title { get; set; }

        /**
         * Timestamp where the record was created
         */ 
        public DateTime Created { get; set; }
        /**
         * external Url to where the image is hosted
         */
        public string Url { get; set; }

        /**
         * Collection of tags for that image
         */
        public virtual IEnumerable<ImageTag> Tags { get; set; }

    }
}
