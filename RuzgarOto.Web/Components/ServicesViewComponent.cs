using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class ServicesViewComponent:ViewComponent
    {
        private readonly IServicesServices servicesServices;

        public ServicesViewComponent(IServicesServices servicesServices)
        {
            this.servicesServices = servicesServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var val = servicesServices.GetAll();
            if (val is null)
            {
                return View(Enumerable.Empty<Services>());
            }
            return View(val);
        }
    }
}
