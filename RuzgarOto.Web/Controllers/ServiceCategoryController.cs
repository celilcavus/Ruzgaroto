using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Controllers
{
    [Authorize]
    public class ServiceCategoryController : Controller
    {
        private readonly IServiceCategoryServices _serviceCategoryServices;

        public ServiceCategoryController(IServiceCategoryServices serviceCategoryServices)
        {
            _serviceCategoryServices = serviceCategoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _serviceCategoryServices.GetOrderedCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceCategory category)
        {
            try
            {
                if (category.ImageFile != null)
                {
                    string imageName = _serviceCategoryServices.ImageUpload(category.ImageFile, FileRoad.ServiceCategory);
                    category.ImageName = imageName;
                }

                category.CreatedDate = DateTime.Now;
                category.UpdatedDate = DateTime.Now;

                _serviceCategoryServices.Add(category);
                _serviceCategoryServices.SaveChanges();

                TempData["SuccessMessage"] = "Kategori başarıyla oluşturuldu!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _serviceCategoryServices.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(ServiceCategory _category)
        {
            try
            {
                var category = _serviceCategoryServices.GetById(_category.Id);
                
                if (_category.ImageFile != null)
                {
                    // Eski resmi sil
                    if (!string.IsNullOrEmpty(category.ImageName))
                    {
                        _serviceCategoryServices.ImageDelete(category.ImageName, FileRoad.ServiceCategory);
                    }
                    
                    // Yeni resmi yükle
                    string imageName = _serviceCategoryServices.ImageUpload(_category.ImageFile, FileRoad.ServiceCategory);
                    category.ImageName = imageName;
                }

                category.CategoryName = _category.CategoryName;
                category.Description = _category.Description;
                category.ShortDescription = _category.ShortDescription;
                category.DisplayOrder = _category.DisplayOrder;
                category.IconClass = _category.IconClass;
                category.ColorClass = _category.ColorClass;
                category.IsActive = _category.IsActive;
                category.UpdatedDate = DateTime.Now;

                _serviceCategoryServices.Update(category);
                _serviceCategoryServices.SaveChanges();

                TempData["SuccessMessage"] = "Kategori başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
                return View(_category);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _serviceCategoryServices.GetById(id);
                
                // Resmi sil
                if (!string.IsNullOrEmpty(category.ImageName))
                {
                    _serviceCategoryServices.ImageDelete(category.ImageName, FileRoad.ServiceCategory);
                }

                _serviceCategoryServices.Delete(category);
                _serviceCategoryServices.SaveChanges();

                TempData["SuccessMessage"] = "Kategori başarıyla silindi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // Kategoriye ait servisleri göster (Kullanıcı tarafı)
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Services(int id)
        {
            var category = await _serviceCategoryServices.GetCategoryWithServicesAsync(id);
            
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}
