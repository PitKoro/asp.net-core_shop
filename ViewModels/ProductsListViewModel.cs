using Shop.Models;

namespace Shop.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> allProducts { get; set; }
        public IEnumerable<Product> ledgerFavoriteProducts { get; set; }
        public IEnumerable<Product> trezorFavoriteProducts { get; set; }
        public IEnumerable<Product> favoriteBooks { get; set; }
        public string currCategory { get; set; }
    }
}
