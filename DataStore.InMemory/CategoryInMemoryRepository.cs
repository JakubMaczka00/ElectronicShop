using MainBusiness;
using UseCases.DataStoreInterfaces;
using System;
using System.Collections.Generic;

namespace DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;
        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Karta graficzna", Description = "Nvidia" },
                new Category { CategoryId = 2, Name = "Monitor", Description = "LG" },
                new Category { CategoryId = 3, Name = "Procesor", Description = "Intel" },
                new Category { CategoryId = 4, Name = "Laptop", Description = "Acer" },
                new Category { CategoryId = 5, Name = "Klawiatura", Description = "Roccat" },

            };

        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (categories != null && categories.Count > 0)
            {
                var max_id = categories.Max(x => x.CategoryId);
                category.CategoryId = max_id + 1;
            }
            else
            {
                category.CategoryId = 1;
            }
            categories.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            var updatingCategory = GetCategoryById(category.CategoryId);
            if (updatingCategory != null)
            {
                updatingCategory.Name = category.Name;
                updatingCategory.Description = category.Description;
            }
        }
        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }
        public void DeleteCategory(int categoryId)
        {
            categories?.Remove(GetCategoryById(categoryId));
        }
    }
} 