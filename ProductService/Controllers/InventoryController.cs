using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DTO_ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProductServiceLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class InventoryController : Controller
    {
        private IConfiguration _config;
        private ICatalogue _getProduce;
        private IProductManagement _manageProduce;

        public InventoryController(IProductManagement productManagement, ICatalogue catalogue, IConfiguration config)
        {
            _config = config;
            _getProduce = catalogue;
            _manageProduce = productManagement;
            _getProduce.ConfigureSqlDB(_config.GetConnectionString("CatalogueDB"));
            _manageProduce.ConfigureSqlDB(_config.GetConnectionString("ProductManagerDB"));
        }

        [HttpGet]
        public async Task<List<ProductModel>> GetAllProducts(int page, int perPage)
        {
            Task<List<ProductModel>> T = new TaskFactory().StartNew(() => _getProduce.GetProductList(page, perPage));
            await T;
            return T.Result;
        }

        [HttpGet]
        public async Task<ProductModel> GetProductById(int id)
        {
            Task<ProductModel> T = new TaskFactory().StartNew(() => _getProduce.GetProduct(id));
            await T;
            return T.Result;
        }

        [HttpPost]
        public async Task NewProduct([FromBody] ProductModel model)
        {
            Task T = new TaskFactory().StartNew(() => _manageProduce.CreateNewProduct(model));
            await T;
        }

        [HttpPost]
        public async Task UpdateProduct([FromBody] ProductModel model)
        {
            Task T = new TaskFactory().StartNew(() => _manageProduce.UpdateProductInfo(model));
            await T;
        }

        [HttpDelete]
        public async Task RemoveProduct(int id)
        {
            Task T = new TaskFactory().StartNew(() => _manageProduce.DeleteProduct(id));
            await T;
        }

        [HttpPost]
        public async Task<StatusCodeResult> ReserveItem(int id, int quantity)
        {
            Task<ReservationStatus> T = new TaskFactory().StartNew(() => _getProduce.ReserveItem(id, quantity));
            var response = await T;

            if(response == ReservationStatus.NotEnoughItems)
            {
                return StatusCode(404);
            }
            else
            {
                return StatusCode(200);
            }
        }

        [HttpPost]
        public async Task<StatusCodeResult> ReleaseItem(int id, int quantity)
        {
            Task<ReservationStatus> T = new TaskFactory().StartNew(() => _getProduce.ReleaseItem(id, quantity));
            var response = await T;

            if(response == ReservationStatus.NotEnoughItems)
            {
                return StatusCode(406);
            }
            else
            {
                return StatusCode(200);
            }
        }
    }
}
