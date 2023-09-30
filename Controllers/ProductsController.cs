using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWebAPI;
using TestWebAPI.Data;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    { 

        private readonly List<Product> products;

        public ProductsController()
        {
            // 建立假資料
            products = new List<Product>{
            new Product { ProductId = 1, Name = "Apple", Price = 100 },
            new Product { ProductId = 2, Name = "Banana", Price = 50 },
            new Product { ProductId = 3, Name = "Duriant", Price = 79 }
            };
        } 
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }
        
    }
}
