using Microsoft.AspNetCore.Mvc;
using Shop.interfaces;
using Shop.Models;
using Shop.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IHttpContextAccessor _httpContextAccessor;

        public CartController(IProductRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            repository = repo;
            _httpContextAccessor = httpContextAccessor;
        }

    public ViewResult Index(/*string returnUrl*/)
        {
            return View(
                new CartIndexViewModel
                {
                    Cart = GetCart(),
                   /* returnUrl = returnUrl*/
                }
            );
        }

        public Cart GetCart()
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            Cart cart = new Cart();
            string sessionCart = _httpContextAccessor.HttpContext.Session.GetString("Cart");

            if (sessionCart == null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart, options));
            }
            else
            {
                cart = JsonSerializer.Deserialize<Cart>(sessionCart)!;
            }



            return cart;
        }

        [HttpPost]
        public JsonResult AddToCart(int id)
        {

            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            Cart cart = GetCart();
            /*Cart cart = new Cart();*/
            Product product = repository.Products
                .FirstOrDefault(p => p.id == id);

            if (product != null)
            {
                cart.AddItem(product, 1);

                
                _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart, options));
            }

            return Json(_httpContextAccessor.HttpContext.Session.GetString("Cart"));
        }
    }
}
