using System;
using System.ComponentModel.DataAnnotations;

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

        public EntityBase()
        {
            DateCreated = DateTime.Now;
            
        }
    }
}
