using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceServiceLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrdersController : Controller
    {
        private IInvoiceManager _InvManager;

        public OrdersController(IInvoiceManager invoiceManager)
        {
            _InvManager = invoiceManager;
        }
    }
}
