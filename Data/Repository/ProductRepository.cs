using Microsoft.EntityFrameworkCore;
using Shop.interfaces;
using Shop.Models;

namespace Shop.Data.Repository
{
    public class ProductRepository: IAllProducts
    {
        private readonly AppDBContent appDBContent;

        public ProductRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Product> Products => appDBContent.Product.Include(c => c.Category);

        public IEnumerable<Product> getFavProducts => appDBContent.Product.Where(p => p.isFavourite).Include(c => c.Category);

        public Product getObjectProduct(int productId) => appDBContent.Product.FirstOrDefault(p => p.id == productId);
    }
}
