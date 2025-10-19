using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly IServicesServices _services;
        private readonly IServiceCategoryServices _categoryServices;

        public ServicesController(IServicesServices services, IServiceCategoryServices categoryServices)
        {
            _services = services;
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Kategorileri ViewBag ile gönder
            ViewBag.Categories = await _categoryServices.GetOrderedCategoriesAsync();
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] Services services)
        {
            string imagename = this._services.ImageUpload(services.Image, FileRoad.Services);
            services.ImageName = imagename;
            int i = this._services.Add(services);
            if (i == 0)
            {
                this._services.ImageDelete(imagename, FileRoad.Services);
            }
            this._services.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var val = this._services.GetById(id);
            this._services.Delete(val);
            this._services.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var val = this._services.GetById(id);
            // Kategorileri ViewBag ile gönder
            ViewBag.Categories = await _categoryServices.GetOrderedCategoriesAsync();
            return View(val);
        }
        [HttpPost]
        public IActionResult Update([FromForm] Services services, [FromRoute] int id)
        {
            var val = this._services.GetById(id);
            if (services is { Image: null })
            {
                ImageUpdate();
            }
            else
            {
                this._services.ImageDelete(val.ImageName, FileRoad.Services);
                string image = this._services.ImageUpload(services.Image, FileRoad.Services);
                val.ImageName = image;
                ImageUpdate();
            }



            void ImageUpdate()
            {
                val.Title = services.Title;
                val.Description = services.Description;
                val.ServiceCategoryId = services.ServiceCategoryId;
                val.IsActive = services.IsActive;
                val.UpdatedDate = DateTime.Now;
                this._services.Update(val);
                this._services.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromRoute]int id)
        {
            var values = this._services.GetById(id);
            if (values is null)
            {
                return View(Enumerable.Empty<Services>());
            }
            return View(values);
        }
    }
}
