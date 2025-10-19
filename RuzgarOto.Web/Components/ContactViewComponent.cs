using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class ContactViewComponent:ViewComponent
    {
        private readonly ICommunicationServices communicationServices;

        public ContactViewComponent(ICommunicationServices communicationServices)
        {
            this.communicationServices = communicationServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var communication = this.communicationServices.GetAll().FirstOrDefault();
            return View(communication);
        }
    }
}
