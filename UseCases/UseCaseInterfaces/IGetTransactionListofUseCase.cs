using MainBusiness;

namespace UseCases
{
    public interface IGetTransactionListofUseCase
    {
        IEnumerable<Transaction> Execute(string sellerName, DateTime startDate, DateTime endDate);
    }
}