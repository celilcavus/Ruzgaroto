using _01.RuzgarOto.Entity;
using _02.RuzgarOto.Model;
using _03.RuzgarOto.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RuzgarOto.Data.Repository
{
    public class MenuSettingsRepository : BaseRepository<MenuSettings>, IMenuSettingsServices
    {
        public MenuSettingsRepository(RuzgarOtoDbContext ruzgarOtoDbContext) : base(ruzgarOtoDbContext)
        {
        }

        public async Task<IEnumerable<MenuSettings>> GetMainMenusAsync()
        {
            return this.ruzgarOtoDbContext.Set<MenuSettings>()
                .Where(x => x.IsActive && !x.IsDropdown && string.IsNullOrEmpty(x.ParentMenuId))
                .OrderBy(x => x.DisplayOrder)
                .ToList();
        }

        public async Task<IEnumerable<MenuSettings>> GetSubMenusAsync(string parentMenuId)
        {
            return this.ruzgarOtoDbContext.Set<MenuSettings>()
                .Where(x => x.IsActive && x.ParentMenuId == parentMenuId)
                .OrderBy(x => x.DisplayOrder)
                .ToList();
        }

        public async Task<IEnumerable<MenuSettings>> GetOrderedMenusAsync()
        {
            return this.ruzgarOtoDbContext.Set<MenuSettings>()
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToList();
        }
    }
}
