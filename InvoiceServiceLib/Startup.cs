using System;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLib;

namespace InvoiceServiceLib
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInvoiceService(this IServiceCollection services)
        {
            services.AddScoped<IDataAccess, SqlDataAccess>();
            services.AddSingleton<IInvoiceManager, InvoiceManager>();
        }
    }
}
