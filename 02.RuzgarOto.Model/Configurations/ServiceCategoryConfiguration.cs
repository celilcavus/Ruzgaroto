using _01.RuzgarOto.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RuzgarOto.Model.Configurations
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CategoryName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.ShortDescription).HasMaxLength(500);
            builder.Property(x => x.ImageName).HasMaxLength(100);
            builder.Property(x => x.IconClass).HasMaxLength(50);
            builder.Property(x => x.ColorClass).HasMaxLength(20);
            builder.Property(x => x.DisplayOrder).IsRequired();
            
            // İlişki tanımı
            builder.HasMany(x => x.Services)
                   .WithOne(x => x.ServiceCategory)
                   .HasForeignKey(x => x.ServiceCategoryId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
