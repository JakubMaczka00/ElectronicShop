using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class AddProductofUseCase : IAddProductofUseCase
    {
        private readonly IProductRepository productRepository;
        public AddProductofUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Execute(Product product)
        {
            productRepository.AddProduct(product);
        }
    }
}
