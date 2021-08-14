using System;
using System.Linq;
using DTO_InvoiceService;
using DataAccessLib;
using System.Collections.Generic;

namespace InvoiceServiceLib
{
    public class InvoiceManager : IInvoiceManager
    {
        private IDataAccess _db;

        public InvoiceManager(IDataAccess db)
        {
            _db = db;
        }

        public void ConfigureSqlDB(string connectionString)
        {
            _db.ConnectionString = connectionString;
        }

        public void CreateOrder(InvoiceModel invoice)
        {
            string sql = "";
            _db.SaveData<dynamic>(sql, invoice);
        }

        public void UpdateDeliveryAddress(string address)
        {
            string sql = "";
            _db.SaveData<dynamic>(sql, new { newAddress = address });
        }
    }
}
