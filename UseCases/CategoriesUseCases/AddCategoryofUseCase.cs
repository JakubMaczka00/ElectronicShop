using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;

namespace UseCases
{
    public class AddCategoryofUseCase : IAddCategoryofUseCase
    {
        private readonly ICategoryRepository categoryRepository;
        public AddCategoryofUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void Execute(Category category)
        {
            categoryRepository.AddCategory(category);
        }
    }
}
