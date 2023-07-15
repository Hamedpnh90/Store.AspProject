using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Store.AspProject.DataLayer.Context;
using Store.AspProject.Services.Interfces;
using Store.AspProject.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Claims

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/login";
    options.LogoutPath = "/LogOut";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
});

#endregion
builder.Services.AddControllersWithViews();
#region DbContext
builder.Services.AddDbContext<AspStoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreAspProject"));
});
#endregion

#region IOC
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductService, ProductService>();



#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();




/// <summary>
/// / app.UseEndpoints(endpoints =>


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "areas",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
    endpoints.MapControllerRoute(
      name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
   



});



/// </summary>





app.Run();
