using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository()
        {
            products = new List<Product>()
            {
                new Product { ProductId = 1, CategoryId = 1, Name = "Nvidia GTX 760", Quantity = 5, Price = 33.22 },
                new Product { ProductId = 2, CategoryId = 1, Name = "Nvidia GTX 1060", Quantity = 8, Price = 36.22 },
                new Product { ProductId = 3, CategoryId = 1, Name = "Nvidia GTX 500", Quantity = 9, Price = 37.22 },
                new Product { ProductId = 4, CategoryId = 1, Name = "Nvidia GTX 2080", Quantity = 2, Price = 32.22 },
                new Product { ProductId = 5, CategoryId = 1, Name = "Nvidia GTX 3080", Quantity = 1, Price = 39.22 },
             };
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (products != null && products.Count > 0)
            {
                var max_id = products.Max(x => x.ProductId);
                product.ProductId = max_id + 1;
            }
            else
            {
                product.ProductId = 1;
            }
            products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            var updatingProduct = GetProductById(product.ProductId);
            if (updatingProduct != null)
            {
                updatingProduct.CategoryId = product.CategoryId;
                updatingProduct.Name = product.Name;
                updatingProduct.Quantity = product.Quantity;
                updatingProduct.Price = product.Price;
            }
        }
        public Product GetProductById(int productId)
        {
            return products?.FirstOrDefault(x => x.ProductId == productId);
        }
        public void DeleteProduct(int productId)
        {
            products?.Remove(GetProductById(productId));
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return products.Where(x => x.CategoryId == categoryId);
        }
    }

 
}
