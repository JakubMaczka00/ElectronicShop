using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class GetTodayTransactionListofUseCase : IGetTodayTransactionListofUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        public GetTodayTransactionListofUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string sellerNamne)
        {
            return transactionRepository.GetByDay(sellerNamne, DateTime.Now);
        }
    }
}
