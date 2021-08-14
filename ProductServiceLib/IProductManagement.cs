using DTO_ProductService;

namespace ProductServiceLib
{
    public interface IProductManagement
    {
        void ConfigureSqlDB(string connectionString);
        void CreateNewProduct(ProductModel product);
        void DeleteProduct(int Id);
        void UpdateProductInfo(ProductModel product);
    }
}