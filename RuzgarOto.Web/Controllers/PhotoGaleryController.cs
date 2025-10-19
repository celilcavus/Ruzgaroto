using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Controllers
{
    [Authorize]
    public class PhotoGaleryController : Controller
    {
        private readonly IPhotoGaleryServices photoGaleryServices;

        public PhotoGaleryController(IPhotoGaleryServices photoGaleryServices)
        {
            this.photoGaleryServices = photoGaleryServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(PhotoGalery photoGalery)
        {
            string imageName = this.photoGaleryServices.ImageUpload(photoGalery.Image, FileRoad.PhotoGalery);
            photoGalery.ImageName = imageName;
            this.photoGaleryServices.Add(photoGalery);
            this.photoGaleryServices.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var val = this.photoGaleryServices.GetById(id);
            this.photoGaleryServices.ImageDelete(val.ImageName, FileRoad.PhotoGalery);
            this.photoGaleryServices.Delete(val);
            this.photoGaleryServices.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var val = this.photoGaleryServices.GetById(id);
            return View(val);
        }
        [HttpPost]
        public IActionResult Update(PhotoGalery photoGalery)
        {
            try
            {
                var val = this.photoGaleryServices.GetById(photoGalery.Id);
                if (photoGalery is { Image: null })
                {
                    Update();
                }
                else
                {
                   
                    this.photoGaleryServices.ImageDelete(val.ImageName, FileRoad.PhotoGalery);
                    string imageName = this.photoGaleryServices.ImageUpload(photoGalery.Image!, FileRoad.PhotoGalery);
                    val.ImageName = imageName;
                    Update();
                }
                void Update()
                {
                    
                    val.IsActive = photoGalery.IsActive;
                    val.UpdatedDate = DateTime.Now;
                    this.photoGaleryServices.Update(val);
                    this.photoGaleryServices.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            
        }

        ///////////////////////
        ///
        [AllowAnonymous]
        public IActionResult PhotoGalery()
        {
            var values = this.photoGaleryServices.GetAll();
            return View(values);
        }

    }
}
