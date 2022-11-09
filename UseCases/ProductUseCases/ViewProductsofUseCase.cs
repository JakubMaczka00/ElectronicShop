using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class ViewProductsofUseCase : IViewProductsofUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductsofUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> Execute()
        {
            return productRepository.GetProducts();
        }
    }
}
