using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Controllers
{
    [Authorize]
    public class HomeCarouselController : Controller
    {
        private readonly IMainTitleServices _mainTitleServices;

        public HomeCarouselController(IMainTitleServices mainTitleServices)
        {
            _mainTitleServices = mainTitleServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MainTitle mainTitle)
        {
            _mainTitleServices.Add(mainTitle);
            _mainTitleServices.SaveChanges();
            return View();
        }
    }
}
