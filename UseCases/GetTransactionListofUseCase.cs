using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class GetTransactionListofUseCase : IGetTransactionListofUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        public GetTransactionListofUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string sellerName, DateTime startDate, DateTime endDate)
        {
            return transactionRepository.SearchByDate(sellerName, startDate, endDate);
        }
    }
}
