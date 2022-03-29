using Shop.interfaces;
using Shop.Models;

namespace Shop.mocks
{
    public class MockProducts : IAllProducts
    {
        private readonly IProductsCategory _categoryProducts = new MockCategory();
        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product {
                        name = "Ledger nano S",
                        shortDesc = "Холодный кошелек",
                        longDesc = "Дешевый холодный кошелек",
                        img = "~/img/ledger_nano_s.jpg",
                        price = 20000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryProducts.AllCategories.First()
                    },
                    new Product {
                        name = "Ledger nano X",
                        shortDesc = "Холодный кошелек",
                        longDesc = "Дорогой холодный кошелек",
                        img = "~/img/ledger_nano_x.jpg",
                        price = 40000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryProducts.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Product> getFavProducts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Product getObjectProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
