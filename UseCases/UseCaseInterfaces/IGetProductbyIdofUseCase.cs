using MainBusiness;

namespace UseCases
{
    public interface IGetProductbyIdofUseCase
    {
        Product Execute(int productId);
    }
}