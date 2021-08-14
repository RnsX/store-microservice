using System.Collections.Generic;
using DTO_ProductService;

namespace ProductServiceLib
{
    public interface ICatalogue
    {
        int CheckInventory(int id);
        void ConfigureSqlDB(string connectionString);
        ProductModel GetProduct(int id);
        List<ProductModel> GetProductList(int page, int perPage);
        ReservationStatus ReleaseItem(int id, int quantity);
        ReservationStatus ReserveItem(int id, int quantity);
        void ResetReservations();
    }
}