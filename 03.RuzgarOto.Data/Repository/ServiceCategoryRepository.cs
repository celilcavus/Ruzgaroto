using _01.RuzgarOto.Entity;
using _02.RuzgarOto.Model;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RuzgarOto.Data.Repository
{
    public class ServiceCategoryRepository : BaseRepository<ServiceCategory>, IServiceCategoryServices
    {
        private readonly Image _image;
        
        public ServiceCategoryRepository(RuzgarOtoDbContext ruzgarOtoDbContext, Image image) : base(ruzgarOtoDbContext)
        {
            this._image = image;
        }

        public async Task<IEnumerable<ServiceCategory>> GetOrderedCategoriesAsync()
        {
            return this.ruzgarOtoDbContext.Set<ServiceCategory>()
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToList();
        }

        public async Task<ServiceCategory?> GetCategoryWithServicesAsync(int categoryId)
        {
            return this.ruzgarOtoDbContext.Set<ServiceCategory>()
                .Include(x => x.Services)
                .FirstOrDefault(x => x.Id == categoryId && x.IsActive);
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
