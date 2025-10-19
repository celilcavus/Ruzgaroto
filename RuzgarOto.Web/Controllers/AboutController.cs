using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutServices _aboutServices;

        public AboutController(IAboutServices aboutServices)
        {
            _aboutServices = aboutServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            try
            {
                this._aboutServices.Add(about);
                string imageName = this._aboutServices.ImageUpload(about.Image, FileRoad.About);
                about.ImageName = imageName;
                this._aboutServices.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var val = this._aboutServices.GetById(id);
            if (val is not null)
            {
                this._aboutServices.Delete(val);
                this._aboutServices.ImageDelete(val.ImageName, FileRoad.About);
                this._aboutServices.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var val = this._aboutServices.GetById(id);
            return View(val);
        }
        [HttpPost]
        public IActionResult Update(About about)
        {
            var val = this._aboutServices.GetById(about.Id);
            if(about is { Image : null})
            {
                ImageUpdate();
            }
            else
            {
                this._aboutServices.ImageDelete(val.ImageName, FileRoad.About);
                string image =  this._aboutServices.ImageUpload(about.Image, FileRoad.About);
                val.ImageName = image;
                ImageUpdate();
            }



            void ImageUpdate()
            {
                val.BaseTitle = about.BaseTitle;
                val.Title = about.Title;
                val.Description = about.Description;
                val.IsActive = about.IsActive;
                val.UpdatedDate = DateTime.Now;
                this._aboutServices.Update(val);
                this._aboutServices.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }
    }
}
