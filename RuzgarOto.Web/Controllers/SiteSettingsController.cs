using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Controllers
{
    [Authorize]
    public class SiteSettingsController : Controller
    {
        private readonly ISiteSettingsServices _siteSettingsServices;

        public SiteSettingsController(ISiteSettingsServices siteSettingsServices)
        {
            _siteSettingsServices = siteSettingsServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var settings = await _siteSettingsServices.GetSiteSettingsAsync();
            return View(settings);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SiteSettings siteSettings)
        {
            try
            {
                var existingSettings = await _siteSettingsServices.GetSiteSettingsAsync();
                
                if (siteSettings.LogoFile != null)
                {
                    // Eski logoyu sil
                    if (!string.IsNullOrEmpty(existingSettings?.LogoName))
                    {
                        _siteSettingsServices.ImageDelete(existingSettings.LogoName, FileRoad.SiteSettings);
                    }
                    
                    // Yeni logoyu yükle
                    string logoName = _siteSettingsServices.ImageUpload(siteSettings.LogoFile, FileRoad.SiteSettings);
                    existingSettings.LogoName = logoName;
                }

                if (siteSettings.FaviconFile != null)
                {
                    // Eski favicon'u sil
                    if (!string.IsNullOrEmpty(existingSettings?.FaviconName))
                    {
                        _siteSettingsServices.ImageDelete(existingSettings.FaviconName, FileRoad.SiteSettings);
                    }
                    
                    // Yeni favicon'u yükle
                    string faviconName = _siteSettingsServices.ImageUpload(siteSettings.FaviconFile, FileRoad.SiteSettings);
                    existingSettings.FaviconName = faviconName;
                }

                // Diğer alanları güncelle
                existingSettings.SiteTitle = siteSettings.SiteTitle;
                existingSettings.SiteDescription = siteSettings.SiteDescription;
                existingSettings.SiteKeywords = siteSettings.SiteKeywords;
                existingSettings.FooterText = siteSettings.FooterText;
                existingSettings.GoogleMapsEmbed = siteSettings.GoogleMapsEmbed;
                existingSettings.GoogleAnalytics = siteSettings.GoogleAnalytics;
                existingSettings.UpdatedDate = DateTime.Now;

                _siteSettingsServices.Update(existingSettings);
                _siteSettingsServices.SaveChanges();

                TempData["SuccessMessage"] = "Site ayarları başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata oluştu: " + ex.Message;
                return View(siteSettings);
            }
        }
    }
}
