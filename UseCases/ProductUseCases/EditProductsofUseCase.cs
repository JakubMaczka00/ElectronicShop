using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class EditProductsofUseCase : IEditProductsofUseCase
    {
        private readonly IProductRepository productRepository;
        public EditProductsofUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;

        }
        public void Execute(Product product)
        {
            productRepository.UpdateProduct(product);

        }
    }
}
