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
    public class MainTitleConfiguration : IEntityTypeConfiguration<MainTitle>
    {
        public void Configure(EntityTypeBuilder<MainTitle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


        }
    }
}
