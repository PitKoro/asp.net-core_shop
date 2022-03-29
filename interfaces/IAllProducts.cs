using Shop.Models;

namespace Shop.interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> getFavProducts { get; set; }
        Product getObjectProduct(int productId);
    }
}
