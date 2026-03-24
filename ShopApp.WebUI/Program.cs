using ShopApp.DataAccess.Abstract;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.WebUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// 1. Servisleri Kaydet
builder.Services.AddControllersWithViews(); // MVC için bu yeterli, RazorPages'i sildik
builder.Services.AddScoped<IProductDal, EfCoreProductDal>();
builder.Services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

var app = builder.Build();

// 2. Geliþtirme Ortamý Ayarlarý
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    SeedDatabase.Seed(); 
}
else
{
    app.UseExceptionHandler("/Error");
}

// 3. Middleware Sýralamasý (Hata Buradaydý!)
app.UseStaticFiles(); // Standart wwwroot klasörü için

// DÝKKAT: node_modules klasörüne eriþmek için yazdýðýn kod
// Eðer hata devam ederse bu satýrýn baþýna // koyup dene
app.CustomStaticFiles();
app.UseRouting(); // Rotalama sadece BÝR kere yazýlmalý

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "products",
        pattern: "products/{category?}",
        defaults: new { controller = "Shop", action = "List" }
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});


// 4. Rota Tanýmý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();