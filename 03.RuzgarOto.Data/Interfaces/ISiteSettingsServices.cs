using _01.RuzgarOto.Entity;
using _04.RuzgarOto.Helper;

namespace _03.RuzgarOto.Data.Interfaces
{
    public interface ISiteSettingsServices : IBaseRepository<SiteSettings>, IImages
    {
        Task<SiteSettings?> GetSiteSettingsAsync();
    }
}
