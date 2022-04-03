using Shop.Models;

namespace Shop.interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> getFavProducts { get; }
        IEnumerable<Product> ThreeFavoriteProductsByManufacturer(string manufacturer);
        Product getObjectProduct(int productId);
    }
}
