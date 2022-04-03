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

        private readonly IProductRepository _allProducts;
        private readonly ICategoryRepository _allCategories;

        public ProductsController(AppDBContent context, IProductRepository iAllProducts, ICategoryRepository iProductsCategory)
        {
            _allProducts = iAllProducts;
            _allCategories = iProductsCategory;
            _context = context;
        }
        
        public ViewResult List()
        {
            ViewData["Title"] = "Главная";
            ProductsListViewModel obj = new ProductsListViewModel();
            obj.allProducts = _allProducts.Products;
            obj.ledgerFavoriteProducts = _allProducts.ThreeFavoriteProductsByManufacturer("Ledger");
            obj.trezorFavoriteProducts = _allProducts.ThreeFavoriteProductsByManufacturer("Trezor");
            obj.favoriteBooks = _allProducts.ThreeFavoriteProductsByManufacturer("Book");
            obj.currCategory = "Aппаратные кошельки";
            return View(obj);
        }
    }
}
