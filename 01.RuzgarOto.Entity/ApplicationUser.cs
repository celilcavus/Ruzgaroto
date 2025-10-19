using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RuzgarOto.Entity
{
	public class ApplicationUser : IdentityUser
	{
		public string FullName { get; set; } = string.Empty;
		public DateTime CreatedDate { get; set; }
		public DateTime? LastLoginDate { get; set; }
		public bool IsActive { get; set; }

		public ApplicationUser()
		{
			CreatedDate = DateTime.Now;
			IsActive = true;
		}
	}
}

