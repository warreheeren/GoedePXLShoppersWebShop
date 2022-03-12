
using Microsoft.AspNetCore.Mvc;
using PXLPro2022Shoppers07.Services;

namespace PXLPro2022Shoppers07.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
      
        ICategoryRepository _categoryRepository;
        public CategoriesMenuViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoryRepository.GetCategories());
        }

    }
}
