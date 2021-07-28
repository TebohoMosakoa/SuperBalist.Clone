﻿using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Api.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public string ModifiedBy { get; set; }

        //images
        //Main image
        [DataType(DataType.ImageUrl)]
        public string? MainImageUrl { get; set; }
        //End of Main Image

        //Second Image
        [DataType(DataType.ImageUrl)]
        public string? Image2Url { get; set; }

        //End of Second Image

        //Third Image
        [DataType(DataType.ImageUrl)]
        public string? Image3Url { get; set; }

        //End of Second Image

        public EntityBase()
        {
            DateCreated = DateTime.Now;
        }
    }
}
