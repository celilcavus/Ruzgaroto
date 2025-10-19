using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace RuzgarOto.Web.Controllers
{
    [Authorize]
    public class CommunicationController : Controller
    {
        private readonly ICommunicationServices communicationServices;

        public CommunicationController(ICommunicationServices communicationServices)
        {
            this.communicationServices = communicationServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var communication = await this.communicationServices.GetOrCreateCommunicationAsync();
            var allCommunications = this.communicationServices.GetAll();
            return View(allCommunications);
        }
        [HttpPost]
        public IActionResult Index([FromForm]Communication communication)
        {
            this.communicationServices.Add(communication);
            this.communicationServices.SaveChanges();
            return View();
        }
     
        public IActionResult Delete(int id)
        {
            Communication communication = this.communicationServices.GetById(id);
            this.communicationServices.Delete(communication);
            this.communicationServices.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Communication communication = this.communicationServices.GetById(id);
            return View(communication);
        }

        [HttpPost]
        public IActionResult Update(Communication _communication)
        {
            try
            {
                Communication communication = this.communicationServices.GetById(_communication.Id);
                
                // Hero Section
                communication.HeroTitle = _communication.HeroTitle;
                communication.HeroSubtitle = _communication.HeroSubtitle;
                communication.HeroDescription1 = _communication.HeroDescription1;
                communication.HeroDescription2 = _communication.HeroDescription2;
                
                // Contact Info
                communication.Phone = _communication.Phone;
                communication.Phone2 = _communication.Phone2;
                communication.Email = _communication.Email;
                communication.Email2 = _communication.Email2;
                communication.Adress = _communication.Adress;
                communication.AddressFull = _communication.AddressFull;
                
                // Social Media
                communication.FacebookUrl = _communication.FacebookUrl;
                communication.TwitterUrl = _communication.TwitterUrl;
                communication.InstagramUrl = _communication.InstagramUrl;
                communication.LinkedinUrl = _communication.LinkedinUrl;
                communication.YoutubeUrl = _communication.YoutubeUrl;
                
                // Footer
                communication.FooterAbout = _communication.FooterAbout;
                communication.CopyrightText = _communication.CopyrightText;
                
                // Working Hours
                communication.WorkingHours = _communication.WorkingHours;
                communication.WorkingHoursWeekend = _communication.WorkingHoursWeekend;
                
                communication.IsActive = _communication.IsActive;
                communication.UpdatedDate = DateTime.Now;
                
                this.communicationServices.Update(communication);
                this.communicationServices.SaveChanges();
                
                TempData["SuccessMessage"] = "İletişim bilgileri başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
                return View(_communication);
            }
        }
    }
}
