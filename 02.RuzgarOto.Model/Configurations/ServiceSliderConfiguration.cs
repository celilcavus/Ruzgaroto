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
    public class ServiceSliderConfiguration : IEntityTypeConfiguration<ServiceSlider>
    {
        public void Configure(EntityTypeBuilder<ServiceSlider> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.ImageName).HasMaxLength(100);
            builder.Property(x => x.DisplayOrder).IsRequired();
        }
    }
}
