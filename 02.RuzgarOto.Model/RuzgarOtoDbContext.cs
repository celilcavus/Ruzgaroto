using _01.RuzgarOto.Entity;
using _02.RuzgarOto.Model.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RuzgarOto.Model
{
	public class RuzgarOtoDbContext : IdentityDbContext<ApplicationUser>
	{
        public RuzgarOtoDbContext(DbContextOptions<RuzgarOtoDbContext> options):base(options)
        {
            
        }
        public DbSet<About>	Abouts { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhotoGalery> PhotoGalleries { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<MainTitle> MainTitles { get; set; }
        
        // Yeni dinamik entity'ler
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<ServiceSlider> ServiceSliders { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<MenuSettings> MenuSettings { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new AboutConfiguration());
			modelBuilder.ApplyConfiguration(new CommunicationConfiguration());
			modelBuilder.ApplyConfiguration(new ContactConfiguration());
			modelBuilder.ApplyConfiguration(new PhotoGaleryConfiguration());
			modelBuilder.ApplyConfiguration(new ServicesConfiguration());
            modelBuilder.ApplyConfiguration(new  MainTitleConfiguration());
            
            // Yeni dinamik entity configurations
            modelBuilder.ApplyConfiguration(new SiteSettingsConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceSliderConfiguration());
            modelBuilder.ApplyConfiguration(new InsuranceCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new MenuSettingsConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceCategoryConfiguration());
		}
	}
}
