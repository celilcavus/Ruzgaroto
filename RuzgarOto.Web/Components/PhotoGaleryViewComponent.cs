using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
    public class PhotoGaleryViewComponent:ViewComponent
    {
        private readonly IPhotoGaleryServices photoGaleryServices;

        public PhotoGaleryViewComponent(IPhotoGaleryServices photoGaleryServices)
        {
            this.photoGaleryServices = photoGaleryServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var val = this.photoGaleryServices.GetAll();
            if (val is null)
            {
                return View(Enumerable.Empty<PhotoGalery>());
            }
            return View(val);
        }
    }
}
