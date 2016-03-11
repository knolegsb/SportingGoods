﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportingGoods.Domain.Abstract;
using Moq;
using SportingGoods.Domain.Entities;
using SportingGoods.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;
using SportingGoods.WebUI.Models;
using System.Web.Mvc;
using SportingGoods.WebUI.HtmlHelpers;

namespace SportingGoods.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 2, Name = "P2" },
                new Product { ProductID = 3, Name = "P3" },
                new Product { ProductID = 4, Name = "P4" },
                new Product { ProductID = 5, Name = "P5" }
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;
            //ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

            // Assert
            //Product[] prodArray = result.ToArray();
            //Assert.IsTrue(prodArray.Length == 2);
            //Assert.AreEqual(prodArray[0].Name, "P4");
            //Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            //Func<int, string> pageUrlDelegate = i => "Page" + i;

            //MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>" + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }
    }
}
