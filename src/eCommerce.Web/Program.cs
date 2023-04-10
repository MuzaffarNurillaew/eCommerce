using eCommerce.Data.DbContexts;
using eCommerce.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using eCommerce.Web.Extensions;
using eCommerce.Data.IRepositories;
using eCommerce.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<eCommerceDbContext>();

builder.Services.AddDbContext<eCommerceDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("eCommerce.Data"));
});


builder.Services.AddAutoMapper(typeof(MapperProfile));

// registrate services to di container
builder.Services.AddCustomServices();

// registrate repository to di container
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
