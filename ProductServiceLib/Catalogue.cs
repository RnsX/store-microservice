using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLib;
using DTO_ProductService;


namespace ProductServiceLib
{


    public class Catalogue : ICatalogue
    {
        public List<ReservedItemModel> ReservedItems;
        private IDataAccess _db;

        public Catalogue(IDataAccess db)
        {
            _db = db;
            ReservedItems = new();
        }

        public void ResetReservations()
        {
            ReservedItems = new();
        }

        public void ConfigureSqlDB(string connectionString)
        {
            _db.ConnectionString = connectionString;
        }

        public ProductModel GetProduct(int id)
        {
            string sql = "";
            return _db.LoadData<ProductModel, dynamic>(sql, new { id = id }).FirstOrDefault();
        }

        public List<ProductModel> GetProductList(int page, int perPage)
        {
            string sql = $"";
            return _db.LoadData<ProductModel, dynamic>(sql, new { });
        }

        public int CheckInventory(int id)
        {
            string sql = "";
            var storage = _db.LoadData<int, dynamic>(sql, new { id = id }).FirstOrDefault();
            var availableItemCount = storage - ReservedItems.Count(x => x.ItemId == id && (DateTime.Now - x.ReservationTime).Minutes <= 15);
            return availableItemCount;

            // Test
            //return 10 - ReservedItems.Count(x => x.ItemId == id && (DateTime.Now - x.ReservationTime).Minutes <= 15);
        }

        public ReservationStatus ReserveItem(int id, int quantity)
        {
            var inventory = CheckInventory(id);
            if (inventory >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    ReservedItems.Add(new ReservedItemModel { ItemId = id, ReservationTime = DateTime.Now });
                }
                return ReservationStatus.Reserved;
            }
            else
            {
                return ReservationStatus.NotEnoughItems;
            }
        }

        public ReservationStatus ReleaseItem(int id, int quantity)
        {
            if (ReservedItems.Count(x => x.ItemId == id) >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    ReservedItems.Remove(ReservedItems.Find(x => x.ItemId == id));
                }
                return ReservationStatus.Released;
            }
            else
            {
                return ReservationStatus.NotEnoughItems;
            }
        }
    }
}
