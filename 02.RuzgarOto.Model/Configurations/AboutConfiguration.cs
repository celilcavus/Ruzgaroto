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
	public class AboutConfiguration : IEntityTypeConfiguration<About>
	{
		public void Configure(EntityTypeBuilder<About> builder)
		{
			builder.HasIndex(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.BaseTitle).HasMaxLength(30).IsRequired();
			builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
			builder.Property(x=>x.Description).HasMaxLength(int.MaxValue).IsRequired();
		}
	}
}
