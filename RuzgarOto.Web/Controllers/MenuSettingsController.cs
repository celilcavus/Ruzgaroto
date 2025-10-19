using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Controllers
{
    [Authorize]
    public class MenuSettingsController : Controller
    {
        private readonly IMenuSettingsServices _menuSettingsServices;
        private readonly IServiceCategoryServices _categoryServices;

        public MenuSettingsController(IMenuSettingsServices menuSettingsServices, IServiceCategoryServices categoryServices)
        {
            _menuSettingsServices = menuSettingsServices;
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var menus = await _menuSettingsServices.GetOrderedMenusAsync();
            return View(menus);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryServices.GetOrderedCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuSettings menu)
        {
            try
            {
                menu.CreatedDate = DateTime.Now;
                menu.UpdatedDate = DateTime.Now;

                _menuSettingsServices.Add(menu);
                _menuSettingsServices.SaveChanges();

                TempData["SuccessMessage"] = "Menü başarıyla oluşturuldu!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
                ViewBag.Categories = await _categoryServices.GetOrderedCategoriesAsync();
                return View(menu);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var menu = _menuSettingsServices.GetById(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _categoryServices.GetOrderedCategoriesAsync();
            return View(menu);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MenuSettings _menu)
        {
            try
            {
                var menu = _menuSettingsServices.GetById(_menu.Id);

                menu.MenuName = _menu.MenuName;
                menu.MenuUrl = _menu.MenuUrl;
                menu.MenuIcon = _menu.MenuIcon;
                menu.DisplayOrder = _menu.DisplayOrder;
                menu.IsActive = _menu.IsActive;
                menu.IsDropdown = _menu.IsDropdown;
                menu.ParentMenuId = _menu.ParentMenuId;
                menu.Target = _menu.Target;
                menu.UpdatedDate = DateTime.Now;

                _menuSettingsServices.Update(menu);
                _menuSettingsServices.SaveChanges();

                TempData["SuccessMessage"] = "Menü başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
                ViewBag.Categories = await _categoryServices.GetOrderedCategoriesAsync();
                return View(_menu);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var menu = _menuSettingsServices.GetById(id);
                _menuSettingsServices.Delete(menu);
                _menuSettingsServices.SaveChanges();

                TempData["SuccessMessage"] = "Menü başarıyla silindi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // Default menüleri oluştur
        [HttpGet]
        public async Task<IActionResult> CreateDefaultMenus()
        {
            try
            {
                // Ana Sayfa
                _menuSettingsServices.Add(new MenuSettings
                {
                    MenuName = "Ana Sayfa",
                    MenuUrl = "/",
                    MenuIcon = "fas fa-home",
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });

                // Hakkımızda
                _menuSettingsServices.Add(new MenuSettings
                {
                    MenuName = "Hakkımızda",
                    MenuUrl = "/About/About",
                    MenuIcon = "fas fa-info-circle",
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });

                // Hizmetler - Dropdown Parent
                _menuSettingsServices.Add(new MenuSettings
                {
                    MenuName = "Hizmetler",
                    MenuUrl = "#",
                    MenuIcon = "fas fa-wrench",
                    DisplayOrder = 3,
                    IsActive = true,
                    IsDropdown = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });

                // Fotoğraf Galerisi
                _menuSettingsServices.Add(new MenuSettings
                {
                    MenuName = "Galeri",
                    MenuUrl = "/PhotoGalery/PhotoGalery",
                    MenuIcon = "fas fa-images",
                    DisplayOrder = 4,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });

                // İletişim
                _menuSettingsServices.Add(new MenuSettings
                {
                    MenuName = "İletişim",
                    MenuUrl = "#contact",
                    MenuIcon = "fas fa-envelope",
                    DisplayOrder = 5,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });

                _menuSettingsServices.SaveChanges();

                TempData["SuccessMessage"] = "Default menüler başarıyla oluşturuldu!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
