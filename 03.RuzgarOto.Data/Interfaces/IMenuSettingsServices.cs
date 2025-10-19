using _01.RuzgarOto.Entity;

namespace _03.RuzgarOto.Data.Interfaces
{
    public interface IMenuSettingsServices : IBaseRepository<MenuSettings>
    {
        Task<IEnumerable<MenuSettings>> GetMainMenusAsync();
        Task<IEnumerable<MenuSettings>> GetSubMenusAsync(string parentMenuId);
        Task<IEnumerable<MenuSettings>> GetOrderedMenusAsync();
    }
}
