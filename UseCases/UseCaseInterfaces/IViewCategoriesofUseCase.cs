using MainBusiness;

namespace UseCases
{
    public interface IViewCategoriesofUseCase
    {
        IEnumerable<Category> Execute();
    }
}