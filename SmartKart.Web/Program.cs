using Microsoft.EntityFrameworkCore;
using SmartKart.Web.Data;
using SmartKart.Web.Repositories;
using SmartKart.Web.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SmartKartContext>(c =>
    c.UseInMemoryDatabase("SmartKartDatabase"), ServiceLifetime.Transient);

#region project services

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IKartRepository, KartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // Configure the HTTP request pipeline.
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

await SeedInMemoryDatabase(app);


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

static async Task SeedInMemoryDatabase(IHost app)
{
    var scope = app.Services.CreateScope();
    var database = scope.ServiceProvider.GetService<SmartKartContext>();
    var logger = LoggerFactory.Create(builder => builder.AddConsole());

    await SmartKartContextSeed.SeedAsync(database, logger);
}