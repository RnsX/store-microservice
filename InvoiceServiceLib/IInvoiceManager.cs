using DTO_InvoiceService;

namespace InvoiceServiceLib
{
    public interface IInvoiceManager
    {
        void ConfigureSqlDB(string connectionString);
        void CreateOrder(InvoiceModel invoice);
        void UpdateDeliveryAddress(string address);
    }
}