using Microsoft.EntityFrameworkCore;
using Shop.interfaces;
using Shop.Models;

namespace Shop.Data.Repository
{
    public class CategoryRepository : IProductsCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;

    }
}
