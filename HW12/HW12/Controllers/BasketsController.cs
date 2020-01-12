using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HW12.DataAccess;
using HW12.Models;
using HW12.Services;
using HW12.DTO;

namespace HW12.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly ShopContext context;
        private readonly PayPalService payPalService;

        public BasketsController(ShopContext context, PayPalService payPalService)
        {
            this.context = context;
            this.payPalService = payPalService;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductsInBasket()
        {
            var basket = await context.Baskets.FirstOrDefaultAsync();

            (basket.Products as List<Product>).AddRange(await context.Products.Where(product => product.Basket.Id == basket.Id).ToListAsync());

            var products = new List<ProductDTO>();

            foreach (var item in basket.Products)
            {
                products.Add(new ProductDTO
                {
                    Cost = item.Cost,
                    Name = item.Name
                });
            }

            return Ok(products);
        }

        [HttpGet]
        public async Task<string> PayBasket()
        {
            var basket = await context.Baskets.FirstOrDefaultAsync();
            (basket.Products as List<Product>).AddRange(await context.Products.Where(product => product.Basket.Id == basket.Id).ToListAsync());
            var url = await payPalService.CreateInvoice(basket);

            return url;
        }
    }
}
