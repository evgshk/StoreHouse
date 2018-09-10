using NUnit.Framework;
using StoreHouse.API.Controllers;
using StoreHouse.API.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StoreHouse.API.Models.Products;

namespace StoreHouse.API.Tests
{
    [TestFixture]
    public class ProductsControllerTests
    {
        private static IProductsService _productsService
        {
            get
            {
                var mock = new Mock<IProductsService>();

                mock.Setup(repo => repo.GetItems()).ReturnsAsync(new ProductListModel());

                return mock.Object;
            }
        }

        [Test]
        public void GetItems_ReturnsOkRequest()
        {
            //arrange
            var controller = new ProductsController(_productsService);
            //act
            var response = controller.GetItems();
            //assert    
            Assert.IsInstanceOf<OkObjectResult>(response);
        }
    }
}
