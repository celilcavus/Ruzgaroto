using System.ComponentModel.DataAnnotations;

namespace RuzgarOto.Web.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Ad Soyad gereklidir")]
		[Display(Name = "Ad Soyad")]
		[StringLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olabilir")]
		public string FullName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Email adresi gereklidir")]
		[EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
		[Display(Name = "Email")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Kullanıcı adı gereklidir")]
		[Display(Name = "Kullanıcı Adı")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3-50 karakter arasında olmalıdır")]
		public string UserName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Şifre gereklidir")]
		[StringLength(100, ErrorMessage = "Şifre en az {2} karakter olmalıdır", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Şifre")]
		public string Password { get; set; } = string.Empty;

		[DataType(DataType.Password)]
		[Display(Name = "Şifre Tekrar")]
		[Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
		public string ConfirmPassword { get; set; } = string.Empty;
	}
}

