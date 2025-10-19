using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Http;


namespace _03.RuzgarOto.Data.Interfaces
{
    public interface IImages
    {
        string ImageUpload(IFormFile formFile, FileRoad type);
        string ImageDelete(string imageName, FileRoad type);
    }
}
