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
    public class MenuSettingsConfiguration : IEntityTypeConfiguration<MenuSettings>
    {
        public void Configure(EntityTypeBuilder<MenuSettings> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.MenuName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.MenuUrl).HasMaxLength(200);
            builder.Property(x => x.MenuIcon).HasMaxLength(50);
            builder.Property(x => x.DisplayOrder).IsRequired();
            builder.Property(x => x.ParentMenuId).HasMaxLength(50);
            builder.Property(x => x.Target).HasMaxLength(20);
        }
    }
}
