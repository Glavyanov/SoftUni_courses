using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data;
using WebShopDemo.Core.Data.Common;
using WebShopDemo.Core.Data.Models.Accounts;
using WebShopDemo.Core.Services;
using static WebShopDemo.Core.Data.ValidationConstants.PolicyConstants;
using static WebShopDemo.Core.Data.ValidationConstants.RolesConstants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddUserSecrets("aspnet-WebShopDemo-F274AD50-FBB7-4413-9D8D-0AC4C8B89766");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDemoDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDemoDbContext>();

builder.Services.AddControllersWithViews();

//Add Policy
builder.Services.AddAuthorization(options =>
    options.AddPolicy(Deletable, policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole(Manager) && context.User.IsInRole(Supervisor))));

//If user want some action but not logged in
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Account/Login";
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
