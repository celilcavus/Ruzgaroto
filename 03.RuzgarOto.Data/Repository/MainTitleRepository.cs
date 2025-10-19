using _01.RuzgarOto.Entity;
using _02.RuzgarOto.Model;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Http;


namespace _03.RuzgarOto.Data.Repository
{
    public class MainTitleRepository : BaseRepository<MainTitle>, IMainTitleServices
    {
        private readonly Image image;
        public MainTitleRepository(RuzgarOtoDbContext ruzgarOtoDbContext, Image image) : base(ruzgarOtoDbContext)
        {
            this.image = image;
        }

        public string ImageDelete(string imageName, FileRoad type)
        {
            return this.image.ImageDelete(imageName,type);
        }

        public string ImageUpload(IFormFile formFile, FileRoad type)
        {
            return this.image.ImageUpload(formFile, type);
        }
    }
}
