namespace Aggregator.Models
{
    public class ProductModel : EntityBaseModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Materials { get; set; }
        public string Dimensions { get; set; }
        public BrandModel Brand { get; set; }
        public CategoryModel Category { get; set; }
        public DepartmentModel Department { get; set; }

    }
}
