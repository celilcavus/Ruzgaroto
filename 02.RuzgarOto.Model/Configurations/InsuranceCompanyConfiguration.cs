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
    public class InsuranceCompanyConfiguration : IEntityTypeConfiguration<InsuranceCompany>
    {
        public void Configure(EntityTypeBuilder<InsuranceCompany> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.WebsiteUrl).HasMaxLength(200);
            builder.Property(x => x.LogoName).HasMaxLength(100);
            builder.Property(x => x.DisplayOrder).IsRequired();
        }
    }
}
