using MainBusiness;

namespace UseCases
{
    public interface IGetTodayTransactionListofUseCase
    {
        IEnumerable<Transaction> Execute(string sellerNamne);
    }
}