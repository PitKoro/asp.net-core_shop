using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.interfaces;
using Shop.Models;
using Shop.ViewModels;


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



            return cart;
        }

        [HttpPost]
        public JsonResult AddToCart(int id)
        {

            

            Cart cart = GetCart();
            /*Cart cart = new Cart();*/
            Product product = repository.Products
                .FirstOrDefault(p => p.id == id);

            if (product != null)
            {
                cart.AddItem(product, 1);
                _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            }

            return Json(_httpContextAccessor.HttpContext.Session.GetString("Cart"));
        }
    }
}
