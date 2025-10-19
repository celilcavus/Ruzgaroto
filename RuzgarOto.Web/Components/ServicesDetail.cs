using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class ServicesDetail:ViewComponent
    {
        private readonly IServicesServices servicesServices;

        public ServicesDetail(IServicesServices servicesServices)
        {
            this.servicesServices = servicesServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            //var values = this.servicesServices.GetById();
            return View();
        }
    }
}
