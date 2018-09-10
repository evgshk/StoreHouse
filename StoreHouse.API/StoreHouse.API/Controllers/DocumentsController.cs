using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreHouse.API.Services.Interfaces;
using StoreHouse.API.Models.Documents;

namespace StoreHouse.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Documents")]
    public class DocumentsController : Controller
    {
        private readonly IDocumentsService _documentsService;
        private readonly IWarehousesService _warehousesService;

        public DocumentsController(IDocumentsService documentsService, IWarehousesService warehousesService)
        {
            _documentsService = documentsService;
            _warehousesService = warehousesService;
        }

        // GET api/Documents/GetItemById
        [HttpGet]
        [Route("GetItemById")]
        public async Task<IActionResult> GetItemById(Guid id)
        {
            try
            {
                return Ok(await _documentsService.GetItem(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Documents/AddItem
        [HttpGet]
        [Route("AddItem")]
        public async Task<IActionResult> AddItem()
        {
            try
            {
                return Ok(await _documentsService.GetItemAddModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Documents/AddItem
        [HttpPost]
        [Route("AddNewItem")]
        public async Task<IActionResult> AddNewItem([FromBody] DocumentAddItemModel model)
        {
            //check availability to transact
            var allowToTransact = _warehousesService
                .PossibleToTransactFrom(model.WarehouseFrom.Id, model.Product.Id, model.Value);

            if (!allowToTransact.Result)
                return BadRequest("Balance of goods smaller than you requested to ship");

            try
            {
                return Ok(await _documentsService.AddItem(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Documents/GetItems
        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                return Ok(await _documentsService.GetItems());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}