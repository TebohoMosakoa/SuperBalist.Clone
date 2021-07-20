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

        public string Image { get; set; }
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
