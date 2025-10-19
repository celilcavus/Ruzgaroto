using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RuzgarOto.Entity
{
    public class SiteSettings : BaseEntity
    {
        public int Id { get; set; }
        public string SiteTitle { get; set; } = "TİA TOPKAPİ";
        public string SiteDescription { get; set; } = "Profesyonel Otomotiv Hizmetleri";
        public string SiteKeywords { get; set; } = "otomotiv, servis, tamir, boya, kaporta";
        
        [NotMapped]
        public IFormFile? LogoFile { get; set; }
        public string LogoName { get; set; } = "logo.png";
        
        [NotMapped]
        public IFormFile? FaviconFile { get; set; }
        public string FaviconName { get; set; } = "favicon.ico";
        
        public string FooterText { get; set; } = "© 2024 Tüm Hakları Saklıdır | ÖZME OTOMOTİV";
        public string GoogleMapsEmbed { get; set; } = "";
        public string GoogleAnalytics { get; set; } = "";
    }
}
