using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class ServicesHomeViewComponent:ViewComponent
    {
        private readonly IServicesServices servicesServices;

        public ServicesHomeViewComponent(IServicesServices servicesServices)
        {
            this.servicesServices = servicesServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = this.servicesServices.Query("SELECT TOP 6 * FROM services  ORDER BY Title DESC");
            
            // Eğer hiç servis yoksa boş liste döndür
            if (!values.Any())
            {
                values = new List<Services>().AsQueryable();
            }
            
            return View(values);
        }
    }
}
