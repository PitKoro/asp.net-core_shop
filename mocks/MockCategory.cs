using Shop.interfaces;
using Shop.Models;


/*Реализовывает интерфейс IProductsCategory*/
namespace Shop.mocks
{
    public class MockCategory : IProductsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get 
            {
                return new List<Category>
                {
                    new Category { categoryName = "Аппаратные кошельки", desc = "Холодные кошельки для криптовалюты"},
                    new Category { categoryName = "Книги", desc = "Книги связанные с технологией блокчейн"},
                    new Category { categoryName = "Хранение резервных копий", desc = "Безопасное хранение резервных копий"}
                };    
            }
        }
    }
}
