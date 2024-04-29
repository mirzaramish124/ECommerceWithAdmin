using ECommerce.Services.Admin.IServices;
using ECommerce.Services.Admin.Services;
using static ECommerceSiteWithAPIs.Utility.SD;
using Microsoft.AspNetCore;
using Microsoft.OpenApi.Models;
using ECommerceSiteWithAPIs.Services.GenericsServices.IServices;
using ECommerceSiteWithAPIs.Services.GenericsServices.Services;
using AutoMapper;
using ECommerceSiteWithAPIs.Utility;
using ECommerceSiteWithAPIs.Services.AdminServices.IServices;
using ECommerceSiteWithAPIs.Services.AdminServices.Services;
using Microsoft.AspNetCore.Mvc.Controllers;
using ECommerce.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.DataAccess.Repositories.Admin.Repository;

var builder = WebApplication.CreateBuilder(args);

WebHost.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
});
// Add services to the container.
//Store api url in variable


//Add Connectionstring
builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"));
});

//APIBaseUrl = builder.Configuration["ECommerceUrls:apibaseurl"];


//Register Client
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IClientService, ClientService>();

//Register Services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMeasurmentRepository, MeasurmentRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();


builder.Services.AddScoped<IBrand, Brands>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategory, Category>();
builder.Services.AddScoped<ICatService, CatService>();
builder.Services.AddScoped<IMeasurment, Measurment>();
builder.Services.AddScoped<IColor, Color>();
builder.Services.AddScoped<IProduct, Product>();
builder.Services.AddHttpContextAccessor();

//Register AutoMapper
IMapper mapper = MappingConfig.Registermaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ECommerce APIs",
        Version = "v1",
        Description = "An APIs to performs ECommerce site operations",
    });
});


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

app.UseSwagger(x => x.SerializeAsV2 = true);
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce API V1");
});

app.MapControllerRoute(
    name: "areas",
    pattern: "{area=Admin}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//void applyMigration()
//{
//    var scope = builder.Services.AddScoped();
//}
