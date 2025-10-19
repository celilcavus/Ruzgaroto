using _01.RuzgarOto.Entity;
using _02.RuzgarOto.Model;
using _03.RuzgarOto.Data.Interfaces;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RuzgarOto.Data.Repository
{
    public class SiteSettingsRepository : BaseRepository<SiteSettings>, ISiteSettingsServices
    {
        private readonly Image _image;
        
        public SiteSettingsRepository(RuzgarOtoDbContext ruzgarOtoDbContext, Image image) : base(ruzgarOtoDbContext)
        {
            this._image = image;
        }

        public async Task<SiteSettings?> GetSiteSettingsAsync()
        {
            var settings = this.ruzgarOtoDbContext.Set<SiteSettings>().FirstOrDefault();
            if (settings == null)
            {
                // İlk kez çalıştırılıyorsa default ayarları oluştur
                settings = new SiteSettings
                {
                    SiteTitle = "TİA TOPKAPİ",
                    SiteDescription = "Profesyonel Otomotiv Hizmetleri",
                    SiteKeywords = "otomotiv, servis, tamir, boya, kaporta",
                    LogoName = "logo.png",
                    FaviconName = "favicon.ico",
                    FooterText = "© 2024 Tüm Hakları Saklıdır | ÖZME OTOMOTİV",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                
                this.Add(settings);
                this.SaveChanges();
            }
            return settings;
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
