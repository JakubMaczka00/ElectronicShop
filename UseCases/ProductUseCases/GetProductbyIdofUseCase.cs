using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class GetProductbyIdofUseCase : IGetProductbyIdofUseCase
    {
        private readonly IProductRepository productRepository;

        public GetProductbyIdofUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product Execute(int productId)
        {
            return productRepository.GetProductById(productId);
        }

    }
}
