using Microsoft.AspNetCore.Mvc;
using Shop.interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts _allProducts;
        private readonly IProductsCategory _allCategories;

        public ProductsController(IAllProducts iAllProducts, IProductsCategory iProductsCategory)
        {
            _allProducts = iAllProducts;
            _allCategories = iProductsCategory;
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
