using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RuzgarOto.Entity
{
	public class Communication:BaseEntity
	{
        public int Id { get; set; }
        
        // Ana Sayfa Hero Bölümü
        public string HeroTitle { get; set; } = "TİA ŞASECİ AHMET OTOMOTİV";
        public string HeroSubtitle { get; set; } = "TOPKAPI BAYİ";
        public string HeroDescription1 { get; set; } = "TİA Otomotiv firması olarak tüm marka ve modeldeki araçlarınızın;";
        public string HeroDescription2 { get; set; } = "bakım, onarım ve yedek parça hizmetini sunuyoruz.";
        
        // İletişim Bilgileri
        public string Phone { get; set; } = "0 (212) 613 15 60";
        public string Phone2 { get; set; } = "+90 501 150 50 60";
        public string Email { get; set; } = "topkapi@tiaotomotiv.com.tr";
        public string Email2 { get; set; } = "ozmeotomotiv@gmail.com";
        public string Adress { get; set; } = "İstanbul, Türkiye";
        public string AddressFull { get; set; } = "Davutpaşa, Davutpaşa Cd., 34200 Topkapı/Zeytinburnu/İstanbul";
        
        // Sosyal Medya
        public string FacebookUrl { get; set; } = "#";
        public string TwitterUrl { get; set; } = "#";
        public string InstagramUrl { get; set; } = "#";
        public string LinkedinUrl { get; set; } = "#";
        public string YoutubeUrl { get; set; } = "#";
        
        // Footer Bilgileri
        public string FooterAbout { get; set; } = "Şirketimiz hakkında detaylı bilgi burada yer alabilir. Misyonumuz, vizyonumuz ve değerlerimizden bahsedebiliriz.";
        public string CopyrightText { get; set; } = "© 2024 Tüm Hakları Saklıdır | ÖZME OTOMOTİV";
        
        // Çalışma Saatleri
        public string WorkingHours { get; set; } = "Pazartesi - Cumartesi: 09:00 - 18:00";
        public string WorkingHoursWeekend { get; set; } = "Pazar: Kapalı";
    }
}
