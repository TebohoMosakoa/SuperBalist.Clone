using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Models
{
    public class Product : EntityBase
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Materials { get; set; }
        public string Dimensions { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
