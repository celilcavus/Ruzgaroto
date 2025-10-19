using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RuzgarOto.Entity
{
    public class MenuSettings : BaseEntity
    {
        public int Id { get; set; }
        public string MenuName { get; set; } = "";
        public string MenuUrl { get; set; } = "";
        public string MenuIcon { get; set; } = ""; // Font Awesome icon class
        public int DisplayOrder { get; set; } = 1;
        public bool IsActive { get; set; } = true;
        public bool IsDropdown { get; set; } = false;
        public string? ParentMenuId { get; set; } = null; // Dropdown için parent menu
        public string Target { get; set; } = "_self"; // _blank, _self
    }
}
