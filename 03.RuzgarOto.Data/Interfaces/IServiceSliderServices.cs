using _01.RuzgarOto.Entity;
using _04.RuzgarOto.Helper;

namespace _03.RuzgarOto.Data.Interfaces
{
    public interface IServiceSliderServices : IBaseRepository<ServiceSlider>, IImages
    {
        Task<IEnumerable<ServiceSlider>> GetMainSliderItemsAsync();
        Task<IEnumerable<ServiceSlider>> GetOrderedSliderItemsAsync();
    }
}
