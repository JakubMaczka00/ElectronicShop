using BlazorStrap;
using DataStore.InMemory;
using DataStore.SQL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using UseCases;
using UseCases.DataStoreInterfaces;
using WebApp.Data;
using Microsoft.AspNetCore.Identity;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AccountContextConnection");;

builder.Services.AddDbContext<AccountContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AccountContext>();;

// Add services to the container.
//builder.Services.AddBlazorStrap();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<MarketContext>(options=>
{
    options.UseSqlServer("Data Source=DESKTOP-B9HNI96\\CITADEL;Initial Catalog=Market Management;Integrated Security=True");
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p => p.RequireClaim("Postion", "Admin"));
    options.AddPolicy("SellerOnly", p => p.RequireClaim("Postion", "Seller"));
}
);
if (!builder.Services.Any(x => x.ServiceType == typeof(HttpClient)))
{
    // Setup HttpClient for server side in a client side compatible fashion
    builder.Services.AddScoped<HttpClient>(s =>
    {
        // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.
        NavigationManager navman = s.GetRequiredService<NavigationManager>();
        return new HttpClient
        {
            BaseAddress = new Uri(navman.BaseUri)
        };
    });
}
builder.Services.AddBlazorStrap();
// rejestrowanie jednej instancji us�ugi
//builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
//builder.Services.AddScoped<IProductRepository, ProductInMemoryRepository>();
//builder.Services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();
//rejestrowanie uslug do entity framework
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
//rejestrowanie wielu instancji us�ugi
builder.Services.AddTransient<IViewCategoriesofUseCase, ViewCategoriesofUseCase>();
// rejestrowanie us�ugi dodawania kategorii
builder.Services.AddTransient<IAddCategoryofUseCase, AddCategoryofUseCase>();
// rejestrowanie us�ugi edytowania kategorii
builder.Services.AddTransient<IEditCategoryofUseCase, EditCategoryofUseCase>();
// rejestrowania us�ugi zwrocenia kategorii po ID
builder.Services.AddTransient<IGetCategoryByIdofUseCase, GetCategoryByIdofUseCase>();
// rejestrowanie us�ugi usuwania kategorii
builder.Services.AddTransient<IDeleteCategoryofUseCase, DeleteCategoryofUseCase>();
// rejestrowania us�ugi wy�wietalania produkt�w
builder.Services.AddTransient<IViewProductsofUseCase, ViewProductsofUseCase>();
// rejestrowanie us�ugi dodawania produkt�w
builder.Services.AddTransient<IAddProductofUseCase, AddProductofUseCase>();
// rejestrowanie us�ugi edycji produkt�w
builder.Services.AddTransient<IEditProductsofUseCase, EditProductsofUseCase>();
// rejestrowanie us�ugi zwr�cenia produktu po ID
builder.Services.AddTransient<IGetProductbyIdofUseCase, GetProductbyIdofUseCase>();
// rejestrowanie us�ugi usuwania produkt�w
builder.Services.AddTransient<IDeleteProductofUseCase, DeleteProductofUseCase>();
// rejestrowanie us�ugi zwracania wszystkich produkt�w z danej kategorii
builder.Services.AddTransient<IViewProductsByCategoryId, ViewProductsByCategoryId>();
// rejestrowanie us�ugi sprzedawania produkt�w
builder.Services.AddTransient<ISellProductOfUseCase, SellProductOfUseCase>();
//rejestrowanie us�ugi wy�wietlania listy transakcji
builder.Services.AddTransient<IListTransactionofUseCase, ListTransactionofUseCase>();
// rejestrowanie uslusgi zwracania dzisiejszych transakcji
builder.Services.AddTransient<IGetTodayTransactionListofUseCase, GetTodayTransactionListofUseCase>();
// rejestrowanie us�ugi wyszukiwania transakcji
builder.Services.AddTransient<IGetTransactionListofUseCase, GetTransactionListofUseCase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapRazorPages();
app.MapFallbackToPage("/_Host");
app.UseAuthorization();
app.UseAuthentication();;

app.Run();
