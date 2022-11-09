using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class ListTransactionofUseCase : IListTransactionofUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetProductbyIdofUseCase getProductbyIdofUseCase;
        public ListTransactionofUseCase(ITransactionRepository transactionRepository, IGetProductbyIdofUseCase getProductbyIdofUseCase)
        {
            this.transactionRepository = transactionRepository;
            this.getProductbyIdofUseCase = getProductbyIdofUseCase;
        }
        public void Execute(string sellerName, int productId, int quantity)
        {
            var product = getProductbyIdofUseCase.Execute(productId);
            transactionRepository.Save(sellerName, productId,product.Name, product.Quantity.Value,quantity, product.Price.Value);
        }
    }
}
