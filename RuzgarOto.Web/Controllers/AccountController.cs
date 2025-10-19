using _01.RuzgarOto.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RuzgarOto.Web.Models;

namespace RuzgarOto.Web.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ILogger<AccountController> _logger;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager,
			ILogger<AccountController> logger)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_logger = logger;
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login(string? returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				ModelState.AddModelError(string.Empty, "Geçersiz email veya şifre.");
				return View(model);
			}

			if (!user.IsActive)
			{
				ModelState.AddModelError(string.Empty, "Hesabınız aktif değil. Lütfen yönetici ile iletişime geçin.");
				return View(model);
			}

			var result = await _signInManager.PasswordSignInAsync(user.UserName!, model.Password, model.RememberMe, lockoutOnFailure: true);

			if (result.Succeeded)
			{
				user.LastLoginDate = DateTime.Now;
				await _userManager.UpdateAsync(user);

				_logger.LogInformation("Kullanıcı giriş yaptı: {Email}", model.Email);

				if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
				{
					return Redirect(returnUrl);
				}
				return RedirectToAction("Index", "Admin");
			}

			if (result.IsLockedOut)
			{
				_logger.LogWarning("Kullanıcı hesabı kilitlendi: {Email}", model.Email);
				ModelState.AddModelError(string.Empty, "Hesabınız çok fazla başarısız giriş denemesi nedeniyle kilitlenmiştir. Lütfen daha sonra tekrar deneyin.");
				return View(model);
			}

			ModelState.AddModelError(string.Empty, "Geçersiz email veya şifre.");
			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = new ApplicationUser
			{
				UserName = model.UserName,
				Email = model.Email,
				FullName = model.FullName,
				CreatedDate = DateTime.Now,
				IsActive = true
			};

			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				_logger.LogInformation("Yeni kullanıcı oluşturuldu: {Email}", model.Email);

				// İlk kullanıcıya Admin rolü ver
				var usersCount = _userManager.Users.Count();
				if (usersCount == 1)
				{
					await _userManager.AddToRoleAsync(user, "Admin");
					_logger.LogInformation("İlk kullanıcıya Admin rolü atandı: {Email}", model.Email);
				}

				await _signInManager.SignInAsync(user, isPersistent: false);
				return RedirectToAction("Index", "Admin");
			}

			foreach (var error in result.Errors)
			{
				if (error.Code == "DuplicateUserName")
				{
					ModelState.AddModelError(string.Empty, "Bu kullanıcı adı zaten kullanılıyor.");
				}
				else if (error.Code == "DuplicateEmail")
				{
					ModelState.AddModelError(string.Empty, "Bu email adresi zaten kayıtlı.");
				}
				else if (error.Code.Contains("Password"))
				{
					ModelState.AddModelError(string.Empty, "Şifre en az 6 karakter olmalı, büyük harf, küçük harf ve rakam içermelidir.");
				}
				else
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			_logger.LogInformation("Kullanıcı çıkış yaptı");
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}

