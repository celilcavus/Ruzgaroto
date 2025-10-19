using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class AboutListViewComponent:ViewComponent
    {
        private readonly IAboutServices aboutServices;

        public AboutListViewComponent(IAboutServices aboutServices)
        {
            this.aboutServices = aboutServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var val = this.aboutServices.GetAll(false);
            if (val is null)
            {
                return View(Enumerable.Empty<About>());
            }
            return View(val);
        }
    }
}
