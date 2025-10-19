using System.ComponentModel.DataAnnotations;

namespace RuzgarOto.Web.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email adresi gereklidir")]
		[EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
		[Display(Name = "Email")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Şifre gereklidir")]
		[DataType(DataType.Password)]
		[Display(Name = "Şifre")]
		public string Password { get; set; } = string.Empty;

		[Display(Name = "Beni Hatırla")]
		public bool RememberMe { get; set; }
	}
}

