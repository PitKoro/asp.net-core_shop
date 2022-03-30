using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.interfaces;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDBContent _context;

        private readonly IAllProducts _allProducts;
        private readonly IProductsCategory _allCategories;

        public ProductsController(AppDBContent context, IAllProducts iAllProducts, IProductsCategory iProductsCategory)
        {
            _allProducts = iAllProducts;
            _allCategories = iProductsCategory;
            _context = context;
        }
        
        public ViewResult List()
        {
            ViewData["Title"] = "Каталог";
            ProductsListViewModel obj = new ProductsListViewModel();
            obj.allProducts = _allProducts.Products;
            obj.currCategory = "Aппаратные кошельки";
            return View(obj);
        }
    }
}
