using Microsoft.AspNetCore.Http;
namespace _04.RuzgarOto.Helper
{
    public class Image
    {
        public string ImageUpload(IFormFile formFile, FileRoad constLocation)
        {
            try
            {
                string[] fileExtentions = { "jpg", "png", "jpeg","JPG","PNG","JPEG" };
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{constLocation}");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileInfo fileInfo = new FileInfo(formFile.FileName);
                foreach (var item in fileExtentions)
                {
                    if (fileInfo.Extension == string.Concat(".", item))
                    {
                        string fileName = Ulid.NewUlid().ToString() + fileInfo.Extension;
                        string fileNameWithPath = Path.Combine(path, fileName);
                        using var stream = new FileStream(fileNameWithPath, FileMode.Create);

                        formFile.CopyTo(stream);
                        return fileName;
                    }
                }
                return String.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return String.Empty;
            }
        }

        public string ImageDelete(string ImageName, FileRoad imageLocation)
        {
            FileInfo file = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imageLocation.ToString(), ImageName));
            if (file.Exists)
            {
                file.Delete();
                return ImageName;
            }
            return string.Empty;
        }
    }
}
