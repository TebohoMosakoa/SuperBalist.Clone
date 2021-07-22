using System;

namespace Aggregator.Models
{
    public class EntityBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public string ModifiedBy { get; set; }

        //images
        //Main image
        public string? MainImageUrl { get; set; }
        public string? MainImageStorageName { get; set; }
        //End of Main Image

        //Second Image
        public string? Image2Url { get; set; }
        public string? Image2StorageName { get; set; }

        //End of Second Image

        //Third Image
        public string? Image3Url { get; set; }
        public string? Image3StorageName { get; set; }

        //End of Second Image
    }
}
