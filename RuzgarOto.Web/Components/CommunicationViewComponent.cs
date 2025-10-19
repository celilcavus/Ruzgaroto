using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class CommunicationViewComponent:ViewComponent
    {
        private readonly ICommunicationServices communicationServices;

        public CommunicationViewComponent(ICommunicationServices communicationServices)
        {
            this.communicationServices = communicationServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = this.communicationServices.GetAll(false);
            if (values is null)
            {
                return View(Enumerable.Empty<Communication>());
            }
            return View(values);
        }
    }
}
