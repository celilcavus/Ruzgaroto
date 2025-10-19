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
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.HasIndex(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.FullName).HasMaxLength(30).IsRequired();
			builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
			builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
			builder.Property(x => x.Message).HasMaxLength(200).IsRequired();
		}
	}
}
