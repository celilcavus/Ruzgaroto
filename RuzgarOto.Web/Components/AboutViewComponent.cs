using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class AboutViewComponent:ViewComponent
    {
        private readonly IAboutServices aboutServices;
        private readonly ICommunicationServices communicationServices;

        public AboutViewComponent(IAboutServices aboutServices, ICommunicationServices communicationServices)
        {
            this.aboutServices = aboutServices;
            this.communicationServices = communicationServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allValues = this.aboutServices.GetAll();
            var values = allValues.LastOrDefault();
            
            if (values == null)
            {
                // Default About değerleri
                values = new About
                {
                    Id = 0,
                    BaseTitle = "Hakkımızda",
                    Title = "TİA TOPKAPİ OTOMOTİV",
                    Description = "Profesyonel otomotiv hizmetleri sunan firmamız, kaliteli hizmet anlayışı ile müşteri memnuniyetini ön planda tutmaktadır. Uzman ekibimiz ve modern teknoloji ile araçlarınızın bakım ve onarım işlemlerini en iyi şekilde gerçekleştiriyoruz.",
                    ImageName = "",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
            }
            
            // İletişim bilgilerini ViewBag ile gönder
            var communication = this.communicationServices.GetAll().FirstOrDefault();
            ViewBag.Communication = communication;
            
            return View(values);
        }
    }
}
