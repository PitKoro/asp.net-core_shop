using Shop.Models;

namespace Shop.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        /*public string returnUrl { get; set; }*/
        public int NumberOfItemsInCart { get; set; }
    }
}
