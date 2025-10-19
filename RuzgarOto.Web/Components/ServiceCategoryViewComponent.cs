using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class ServiceCategoryViewComponent : ViewComponent
    {
        private readonly IServiceCategoryServices _categoryServices;

        public ServiceCategoryViewComponent(IServiceCategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryServices.GetOrderedCategoriesAsync();
            return View(categories);
        }
    }
}
