using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class SellProductOfUseCase : ISellProductOfUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IListTransactionofUseCase listTransactionofUseCase;
        public SellProductOfUseCase(IProductRepository productRepository, IListTransactionofUseCase listTransactionofUseCase)
        {
            this.productRepository = productRepository;
            this.listTransactionofUseCase = listTransactionofUseCase;
        }
        public void Execute(string sellerName,int productId, int quantityToSell)
        {
            var product = productRepository.GetProductById(productId);
            if (product == null) return;
            product.Quantity -= quantityToSell;
            productRepository.UpdateProduct(product);
            listTransactionofUseCase.Execute(sellerName, productId, quantityToSell);
        }
    }
}
