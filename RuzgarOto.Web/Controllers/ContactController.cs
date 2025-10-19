using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactServices _contactServices;

        public ContactController(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.IsActive = true;
            this._contactServices.Add(contact);
            this._contactServices.SaveChanges();
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
