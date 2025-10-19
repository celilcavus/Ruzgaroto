using _01.RuzgarOto.Entity;
using _02.RuzgarOto.Model;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Http;


namespace _03.RuzgarOto.Data.Repository
{
    public class ServicesRepository : BaseRepository<Services>, IServicesServices
    {
        private readonly Image _image;
        public ServicesRepository(RuzgarOtoDbContext ruzgarOtoDbContext, Image image) : base(ruzgarOtoDbContext)
        {
            _image = image;
        }

        public string ImageDelete(string imageName, FileRoad type)
        {
           return this._image.ImageDelete(imageName, type);
        }

        public string ImageUpload(IFormFile formFile, FileRoad type)
        {
           return this._image.ImageUpload(formFile, type);
        }
    }
}
