using System;
using DataAccessLib;
using DTO_ProductService;

namespace ProductServiceLib
{
    public class ProductManagement : IProductManagement
    {
        private IDataAccess _db;

        public ProductManagement(IDataAccess db)
        {
            _db = db;
        }

        public void ConfigureSqlDB(string connectionString)
        {
            _db.ConnectionString = connectionString;
        }

        public void CreateNewProduct(ProductModel product)
        {
            string sql = "";
            _db.SaveData<dynamic>(sql, product);
        }

        public void DeleteProduct(int Id)
        {
            string sql = "";
            _db.SaveData<dynamic>(sql, new { });
        }

        public void UpdateProductInfo(ProductModel product)
        {
            string sql = "";
            _db.SaveData<dynamic>(sql, product);
        }
    }
}
