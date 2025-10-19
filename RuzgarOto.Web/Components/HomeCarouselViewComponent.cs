using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class HomeCarouselViewComponent:ViewComponent
    {
        private readonly IMainTitleServices mainTitleServices;
        private readonly ICommunicationServices communicationServices;

        public HomeCarouselViewComponent(IMainTitleServices mainTitleServices, ICommunicationServices communicationServices)
        {
            this.mainTitleServices = mainTitleServices;
            this.communicationServices = communicationServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mainTitles = this.mainTitleServices.GetAll();
            
            // Eğer hiç MainTitle yoksa boş liste döndür
            if (!mainTitles.Any())
            {
                mainTitles = new List<MainTitle>();
            }
            
            // İletişim bilgilerini al
            var communication = this.communicationServices.GetAll().FirstOrDefault();
            
            // ViewBag ile communication bilgisini gönder
            ViewBag.Communication = communication;
            
            return View(mainTitles);
        }
    }
}
