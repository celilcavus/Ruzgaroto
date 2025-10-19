using _01.RuzgarOto.Entity;
using _04.RuzgarOto.Helper;

namespace _03.RuzgarOto.Data.Interfaces
{
    public interface IServiceCategoryServices : IBaseRepository<ServiceCategory>, IImages
    {
        Task<IEnumerable<ServiceCategory>> GetOrderedCategoriesAsync();
        Task<ServiceCategory?> GetCategoryWithServicesAsync(int categoryId);
    }
}
