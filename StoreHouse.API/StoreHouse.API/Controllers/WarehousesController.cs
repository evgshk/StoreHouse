using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreHouse.API.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using StoreHouse.API.Services.Interfaces;

namespace StoreHouse.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Warehouses")]
    public class WarehousesController : Controller
    {
        private readonly IWarehousesService _warehousesService;

        public WarehousesController(IWarehousesService warehousesService)
        {
            _warehousesService = warehousesService;
        }

        // GET api/Warehouses/GetItemById
        [HttpGet]
        [Route("GetItemById")]
        public async Task<IActionResult> GetItemById(Guid id)
        {
            try
            {
                return Ok(await _warehousesService.GetItem(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Warehouses/GetItems
        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                return Ok(await _warehousesService.GetItems());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}