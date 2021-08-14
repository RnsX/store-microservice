using System;
using DataAccessLib;
using Microsoft.Extensions.DependencyInjection;

namespace ProductServiceLib
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProductService(this IServiceCollection services)
        {
            services.AddSingleton<ICatalogue, Catalogue>();
            services.AddSingleton<IProductManagement, ProductManagement>();
            services.AddSingleton<IDataAccess, SqlDataAccess>();
        }
    }
}
