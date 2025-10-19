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
	public class CommunicationConfiguration : IEntityTypeConfiguration<Communication>
	{
		public void Configure(EntityTypeBuilder<Communication> builder)
		{
			builder.HasIndex(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			// Hero Section
			builder.Property(x => x.HeroTitle).HasMaxLength(200);
			builder.Property(x => x.HeroSubtitle).HasMaxLength(200);
			builder.Property(x => x.HeroDescription1).HasMaxLength(500);
			builder.Property(x => x.HeroDescription2).HasMaxLength(500);
			
			// Contact Info
			builder.Property(x => x.Phone).HasMaxLength(50);
			builder.Property(x => x.Phone2).HasMaxLength(50);
			builder.Property(x => x.Email).HasMaxLength(100);
			builder.Property(x => x.Email2).HasMaxLength(100);
			builder.Property(x => x.Adress).HasMaxLength(200);
			builder.Property(x => x.AddressFull).HasMaxLength(500);
			
			// Social Media
			builder.Property(x => x.FacebookUrl).HasMaxLength(200);
			builder.Property(x => x.TwitterUrl).HasMaxLength(200);
			builder.Property(x => x.InstagramUrl).HasMaxLength(200);
			builder.Property(x => x.LinkedinUrl).HasMaxLength(200);
			builder.Property(x => x.YoutubeUrl).HasMaxLength(200);
			
			// Footer
			builder.Property(x => x.FooterAbout).HasMaxLength(1000);
			builder.Property(x => x.CopyrightText).HasMaxLength(200);
			
			// Working Hours
			builder.Property(x => x.WorkingHours).HasMaxLength(200);
			builder.Property(x => x.WorkingHoursWeekend).HasMaxLength(200);
		}
	}
}
