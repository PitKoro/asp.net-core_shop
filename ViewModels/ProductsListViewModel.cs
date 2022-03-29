using Shop.Models;

namespace Shop.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> allProducts { get; set; }
        public string currCategory { get; set; }
    }
}
