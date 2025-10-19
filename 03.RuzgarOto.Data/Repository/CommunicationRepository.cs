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
    public class CommunicationRepository : BaseRepository<Communication>, ICommunicationServices
    {
        public CommunicationRepository(RuzgarOtoDbContext ruzgarOtoDbContext) : base(ruzgarOtoDbContext)
        {
        }

        public async Task<Communication> GetOrCreateCommunicationAsync()
        {
            var communication = this.ruzgarOtoDbContext.Set<Communication>().FirstOrDefault();
            
            if (communication == null)
            {
                // İlk kez çalıştırılıyorsa default değerlerle oluştur
                communication = new Communication
                {
                    HeroTitle = "TİA ŞASECİ AHMET OTOMOTİV",
                    HeroSubtitle = "TOPKAPI BAYİ",
                    HeroDescription1 = "TİA Otomotiv firması olarak tüm marka ve modeldeki araçlarınızın;",
                    HeroDescription2 = "bakım, onarım ve yedek parça hizmetini sunuyoruz.",
                    Phone = "0 (212) 613 15 60",
                    Phone2 = "+90 501 150 50 60",
                    Email = "topkapi@tiaotomotiv.com.tr",
                    Email2 = "ozmeotomotiv@gmail.com",
                    Adress = "İstanbul, Türkiye",
                    AddressFull = "Davutpaşa, Davutpaşa Cd., 34200 Topkapı/Zeytinburnu/İstanbul",
                    FacebookUrl = "#",
                    TwitterUrl = "#",
                    InstagramUrl = "#",
                    LinkedinUrl = "#",
                    YoutubeUrl = "#",
                    FooterAbout = "Şirketimiz hakkında detaylı bilgi burada yer alabilir. Misyonumuz, vizyonumuz ve değerlerimizden bahsedebiliriz.",
                    CopyrightText = "© 2024 Tüm Hakları Saklıdır | ÖZME OTOMOTİV",
                    WorkingHours = "Pazartesi - Cumartesi: 09:00 - 18:00",
                    WorkingHoursWeekend = "Pazar: Kapalı",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                
                this.Add(communication);
                this.SaveChanges();
            }
            else if (string.IsNullOrEmpty(communication.Phone2))
            {
                // Mevcut kayıt varsa ama yeni alanlar boşsa, default değerleri ata
                communication.Phone2 = communication.Phone2 ?? "+90 501 150 50 60";
                communication.Email2 = communication.Email2 ?? "ozmeotomotiv@gmail.com";
                communication.HeroTitle = communication.HeroTitle ?? "TİA ŞASECİ AHMET OTOMOTİV";
                communication.HeroSubtitle = communication.HeroSubtitle ?? "TOPKAPI BAYİ";
                communication.HeroDescription1 = communication.HeroDescription1 ?? "TİA Otomotiv firması olarak tüm marka ve modeldeki araçlarınızın;";
                communication.HeroDescription2 = communication.HeroDescription2 ?? "bakım, onarım ve yedek parça hizmetini sunuyoruz.";
                communication.AddressFull = communication.AddressFull ?? "Davutpaşa, Davutpaşa Cd., 34200 Topkapı/Zeytinburnu/İstanbul";
                communication.FacebookUrl = communication.FacebookUrl ?? "#";
                communication.TwitterUrl = communication.TwitterUrl ?? "#";
                communication.InstagramUrl = communication.InstagramUrl ?? "#";
                communication.LinkedinUrl = communication.LinkedinUrl ?? "#";
                communication.YoutubeUrl = communication.YoutubeUrl ?? "#";
                communication.FooterAbout = communication.FooterAbout ?? "Şirketimiz hakkında detaylı bilgi burada yer alabilir. Misyonumuz, vizyonumuz ve değerlerimizden bahsedebiliriz.";
                communication.CopyrightText = communication.CopyrightText ?? "© 2024 Tüm Hakları Saklıdır | ÖZME OTOMOTİV";
                communication.WorkingHours = communication.WorkingHours ?? "Pazartesi - Cumartesi: 09:00 - 18:00";
                communication.WorkingHoursWeekend = communication.WorkingHoursWeekend ?? "Pazar: Kapalı";
                communication.UpdatedDate = DateTime.Now;
                
                this.Update(communication);
                this.SaveChanges();
            }
            
            return communication;
        }
    }
}
