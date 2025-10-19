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
    public class SiteSettingsConfiguration : IEntityTypeConfiguration<SiteSettings>
    {
        public void Configure(EntityTypeBuilder<SiteSettings> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.SiteTitle).HasMaxLength(100).IsRequired();
            builder.Property(x => x.SiteDescription).HasMaxLength(200);
            builder.Property(x => x.SiteKeywords).HasMaxLength(500);
            builder.Property(x => x.LogoName).HasMaxLength(100);
            builder.Property(x => x.FaviconName).HasMaxLength(100);
            builder.Property(x => x.FooterText).HasMaxLength(200);
            builder.Property(x => x.GoogleMapsEmbed).HasMaxLength(1000);
            builder.Property(x => x.GoogleAnalytics).HasMaxLength(1000);
        }
    }
}
