using _01.RuzgarOto.Entity;
using _02.RuzgarOto.Model;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RuzgarOto.Data.Repository
{
    public class AboutRepository : BaseRepository<About>, IAboutServices
	{
        private readonly Image _image;
        public AboutRepository(RuzgarOtoDbContext ruzgarOtoDbContext, Image ımage) : base(ruzgarOtoDbContext)
        {
            this._image = ımage;
        }

        public string ImageDelete(string imageName, FileRoad type)
        {
            return this._image.ImageDelete(imageName,type);
        }

        public string ImageUpload(IFormFile formFile, FileRoad type)
        {
            return this._image.ImageUpload(formFile,type);
        }
    }
}
