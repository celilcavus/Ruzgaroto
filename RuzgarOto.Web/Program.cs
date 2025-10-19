using _01.RuzgarOto.Entity;
using _02.RuzgarOto.Model;
using _03.RuzgarOto.Data.Interfaces;
using _03.RuzgarOto.Data.Repository;
using _04.RuzgarOto.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RuzgarOtoDbContext>(options =>
{
	options.UseSqlServer(connectionString, sqlOptions =>
	{
		sqlOptions.MigrationsAssembly("RuzgarOto.Web");
		sqlOptions.EnableRetryOnFailure(
			maxRetryCount: 5,
			maxRetryDelay: TimeSpan.FromSeconds(30),
			errorNumbersToAdd: null);
	});
});

// Identity Configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	// Password settings
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequiredLength = 6;

	// Lockout settings
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.AllowedForNewUsers = true;

	// User settings
	options.User.RequireUniqueEmail = true;
	options.SignIn.RequireConfirmedEmail = false;
})
.AddEntityFrameworkStores<RuzgarOtoDbContext>()
.AddDefaultTokenProviders();

// Cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Account/Login";
	options.LogoutPath = "/Account/Logout";
	options.AccessDeniedPath = "/Account/AccessDenied";
	options.ExpireTimeSpan = TimeSpan.FromHours(24);
	options.SlidingExpiration = true;
});

builder.Services.AddScoped<RuzgarOtoDbContext, RuzgarOtoDbContext>();
builder.Services.AddScoped<IAboutServices, AboutRepository>();
builder.Services.AddScoped<ICommunicationServices, CommunicationRepository>();
builder.Services.AddScoped<IContactServices, ContactRepository>();
builder.Services.AddScoped<IPhotoGaleryServices, PhotoGaleryRepository>();
builder.Services.AddScoped<IServicesServices, ServicesRepository>();
builder.Services.AddScoped<IMainTitleServices,MainTitleRepository>();

// Yeni dinamik servisler
builder.Services.AddScoped<ISiteSettingsServices, SiteSettingsRepository>();
builder.Services.AddScoped<IServiceSliderServices, ServiceSliderRepository>();
builder.Services.AddScoped<IInsuranceCompanyServices, InsuranceCompanyRepository>();
builder.Services.AddScoped<IMenuSettingsServices, MenuSettingsRepository>();
builder.Services.AddScoped<IServiceCategoryServices, ServiceCategoryRepository>();

builder.Services.AddScoped<Image, Image>();

var app = builder.Build();

// Seed roles
using (var scope = app.Services.CreateScope())
{
	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	
	// Admin rolünü oluştur
	if (!await roleManager.RoleExistsAsync("Admin"))
	{
		await roleManager.CreateAsync(new IdentityRole("Admin"));
	}
	
	// User rolünü oluştur (isteğe bağlı)
	if (!await roleManager.RoleExistsAsync("User"))
	{
		await roleManager.CreateAsync(new IdentityRole("User"));
	}
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
