using MainBusiness;

namespace UseCases
{
    public interface IGetCategoryByIdofUseCase
    {
        Category Execute(int categoryId);
    }
}