using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext database;
        public CategoryRepository(MarketContext database)
        {
            this.database = database;   
        }
        void ICategoryRepository.AddCategory(Category category)
        {
            database.Categories.Add(category);
            database.SaveChanges();
        }

        void ICategoryRepository.DeleteCategory(int categoryId)
        {
            var category = database.Categories.Find(categoryId);
            if (category != null) return;
            database.Categories.Remove(category);
            database.SaveChanges();
        }

        IEnumerable<Category> ICategoryRepository.GetCategories()
        {
            return database.Categories.ToList();
        }

        Category ICategoryRepository.GetCategoryById(int categoryId)
        {
            return database.Categories.Find(categoryId);
        }

        void ICategoryRepository.UpdateCategory(Category category)
        {
            var categ = database.Categories.Find(category.CategoryId);
            categ.Name = category.Name;
            categ.Description = category.Description;
            database.SaveChanges();
        }
    }
}
