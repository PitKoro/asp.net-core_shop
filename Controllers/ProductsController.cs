using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.interfaces;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductsController( IProductRepository iAllProducts, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = iAllProducts;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public ViewResult List()
        {


            ViewData["Title"] = "Главная";
            ProductsListViewModel obj = new ProductsListViewModel();
            obj.allProducts = _productRepository.Products;
            obj.ledgerFavoriteProducts = _productRepository.ThreeFavoriteProductsByManufacturer("Ledger");
            obj.trezorFavoriteProducts = _productRepository.ThreeFavoriteProductsByManufacturer("Trezor");
            obj.favoriteBooks = _productRepository.ThreeFavoriteProductsByManufacturer("Book");
            obj.NumberOfItemsInCart = NumberOfItemsInCart();
            obj.currCategory = "Aппаратные кошельки";
            return View(obj);
        }

        private int NumberOfItemsInCart()
        {
            Cart cart = new Cart();
            string sessionCartJson = _httpContextAccessor.HttpContext.Session.GetString("Cart");

            if (sessionCartJson == null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            }
            else
            {
                cart = JsonConvert.DeserializeObject<Cart>(sessionCartJson)!;
            }

            return cart.totalQuantity;
        }

    }
}
