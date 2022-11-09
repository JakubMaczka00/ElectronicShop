namespace UseCases
{
    public interface IListTransactionofUseCase
    {
        void Execute(string sellerName, int productId, int quantity);
    }
}