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
	internal class ServicesConfiguration : IEntityTypeConfiguration<Services>
	{
		public void Configure(EntityTypeBuilder<Services> builder)
		{
			builder.HasIndex(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.Title).HasMaxLength(200);
			builder.Property(x => x.Description).HasMaxLength(int.MaxValue);
			builder.Property(x => x.ImageName).HasMaxLength(100);
			
			// Foreign key
			builder.HasOne(x => x.ServiceCategory)
				   .WithMany(x => x.Services)
				   .HasForeignKey(x => x.ServiceCategoryId)
				   .OnDelete(DeleteBehavior.SetNull);
		}
	}
}
