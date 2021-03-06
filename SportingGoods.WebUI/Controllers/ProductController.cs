﻿using SportingGoods.Domain.Abstract;
using SportingGoods.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportingGoods.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = repository.Products
                            .Where(p => category == null || p.Category == category)
                            .OrderBy(p => p.ProductID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //TotalItems = repository.Products.Count()
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        //public ViewResult List(int page = 1)
        //{
        //    return View(repository.Products.OrderBy(p => p.ProductID)
        //                                    .Skip((page - 1) * PageSize)
        //                                    .Take(PageSize));
        //}

        //public ViewResult List()
        //{
        //    //var products = repository.Products;
        //    return View(repository.Products);
        //    //return View(repository.Table);
        //}
    }
}