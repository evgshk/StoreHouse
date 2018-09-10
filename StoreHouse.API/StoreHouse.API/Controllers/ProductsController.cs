using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreHouse.API.Services.Interfaces;

namespace StoreHouse.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET api/Products/GetItemById
        [HttpGet]
        [Route("GetItemById")]
        public async Task<IActionResult> GetItemById(Guid id)
        {
            try
            {
                return Ok(await _productsService.GetItem(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Products/GetItems
        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                return Ok(await _productsService.GetItems());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  
    }
}