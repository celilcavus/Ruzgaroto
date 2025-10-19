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
	public class PhotoGaleryConfiguration : IEntityTypeConfiguration<PhotoGalery>
	{
		public void Configure(EntityTypeBuilder<PhotoGalery> builder)
		{
			builder.HasIndex(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
		}
	}
}
