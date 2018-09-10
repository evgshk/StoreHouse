using StoreHouse.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreHouse.API.Models.Documents;
using StoreHouse.API.Data.Repository.Interfaces;
using StoreHouse.API.Models.Warehouses;
using StoreHouse.API.Models.Products;
using Microsoft.EntityFrameworkCore;
using StoreHouse.API.Data.Repository.Implementation;
using StoreHouse.API.Data.StoreHouseStorage.Domain;

namespace StoreHouse.API.Services.Implementation
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IDocumentsRepository _documentsRepo;
        private readonly IWarehousesRepository _warehouseRepo;
        private readonly IProductsRepository _productRepo;

        public DocumentsService(IDocumentsRepository documentsRepo, IWarehousesRepository warehouseRepo, IProductsRepository productRepo)
        {
            this._documentsRepo = documentsRepo;
            this._warehouseRepo = warehouseRepo;
            this._productRepo = productRepo;
        }

        public async Task<bool> AddItem(DocumentAddItemModel model)
        {
            try
            {
                //Это "немножко" плохой код; ввиду реализации всей инфраструктуры я потратил достаточное количество времени(для тестового задания).
                //Реализация методов обновления остатков должна быть заложена в репозиторий, что я не успеваю сделать :)
                //Тем не менее требуемый функционал реализован.
                var ctx = new StoreHouseContext();

                var entityFrom = ctx.Stocks.SingleOrDefault(x => x.ProductId == model.Product.Id && x.WarehouseId == model.WarehouseFrom.Id);
                entityFrom.Value -= model.Value;
                ctx.Stocks.Update(entityFrom);

                var entityTo = ctx.Stocks.SingleOrDefault(x => x.ProductId == model.Product.Id && x.WarehouseId == model.WarehouseTo.Id);
                entityTo.Value += model.Value;
                ctx.Stocks.Update(entityTo);
                //плохой код закончен

                var warehouseFromItem = await _warehouseRepo.GetItemByid(model.WarehouseFrom.Id);
                //var warehouseFromStock = warehouseFromItem.Stocks.SingleOrDefault(x => x.ProductId == model.Product.Id);
                //warehouseFromStock.Value -= model.Value;

                //var warehouseToItem = await _warehouseRepo.GetItemByid(model.WarehouseTo.Id);
                //var warehouseToStock = warehouseFromItem.Stocks.SingleOrDefault(x => x.ProductId == model.Product.Id);
                //warehouseToStock.Value += model.Value;

                _documentsRepo.Add(new Documents
                {
                    StockId = model.Product.Id,
                    WarehouseFrom = model.WarehouseFrom.Id,
                    WarehouseTo = model.WarehouseTo.Id,
                    Value = model.Value

                });

                ctx.SaveChanges();//сохранение контекста, вызванное плохим кодом выше
                _documentsRepo.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<DocumentItemModel> GetItem(Guid id)
        {
            var item = await _documentsRepo.GetItemByid(id);

            return new DocumentItemModel
            {
                Id = item.Id,
                WarehouseFrom = new WarehouseItemModel
                {
                    Id = item.WarehouseFromNavigation.Id,
                    Name = item.WarehouseFromNavigation.Name
                },
                WarehouseTo = new WarehouseItemModel
                {
                    Id = item.WarehouseToNavigation.Id,
                    Name = item.WarehouseToNavigation.Name
                },
                Product = new ProductItemModel
                {
                    Id = item.Stock.Id,
                    Name = item.Stock.Name
                },
                Value = (int)item.Value
            };
        }

        public async Task<DocumentAddItemModel> GetItemAddModel()
        {
            var availableWarehouses = await _warehouseRepo.GetItems().ToListAsync();
            var availableProducts = await _productRepo.GetItems().ToListAsync();

            return new DocumentAddItemModel
            {
                WarehouseFromDdl = availableWarehouses.Select(x => new WarehouseItemModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                WarehouseToDdl = availableWarehouses.Select(x => new WarehouseItemModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                ProductDdl = availableProducts.Select(x => new ProductItemModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
        }

        public async Task<DocumentListModel> GetItems()
        {
            var data = await _documentsRepo.GetItems()
                .ToListAsync();

            return new DocumentListModel
            {
                Items = data.Select(x => new DocumentItemModel
                {
                    Id = x.Id,
                    WarehouseFrom = new WarehouseItemModel
                    {
                        Id = x.WarehouseFromNavigation.Id,
                        Name = x.WarehouseFromNavigation.Name
                    },
                    WarehouseTo = new WarehouseItemModel
                    {
                        Id = x.WarehouseToNavigation.Id,
                        Name = x.WarehouseToNavigation.Name
                    },
                    Product = new ProductItemModel
                    {
                        Id = x.Stock.Id,
                        Name = x.Stock.Name
                    },
                    Value = (int)x.Value
                }).ToList()
            };
        }
    }
}
