using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class GetCategoryByIdofUseCase : IGetCategoryByIdofUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public GetCategoryByIdofUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Category Execute(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }
    }
}
