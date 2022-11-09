using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class DeleteProductofUseCase : IDeleteProductofUseCase
    {
        private readonly IProductRepository productRepository;
        public DeleteProductofUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void DeleteProduct(int productId)
        {
            productRepository.DeleteProduct(productId);
        }
    }
}
