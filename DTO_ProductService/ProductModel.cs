using System;
namespace DTO_ProductService
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ItemsAvailable { get; set; }
        public string Category { get; set; }
    }
}
