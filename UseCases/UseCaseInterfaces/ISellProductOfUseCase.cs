namespace UseCases
{
    public interface ISellProductOfUseCase
    {
        void Execute(string sellerName, int productId, int quantityToSell);
    }
}