using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Store.Core.Modules.Brands;
using Store.Core.Modules.Brands.Interfaces;
using Store.Core.Modules.Categories;
using Store.Core.Modules.Categories.Interfaces;
using Store.Core.Modules.Products;
using Store.Core.Modules.Products.Interfaces;
using Store.Core.Modules.Suppliers;
using Store.Core.Modules.Suppliers.Interfaces;
using Store.Db;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreDbContext>(options =>
{
    var connectionStr = builder.Configuration.GetConnectionString("Store") ??
        throw new Exception("Connection string 'Store' not found");
    options.UseSqlServer(connectionStr);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.Load("Store.Core"));
builder.Services.AddValidatorsFromAssembly(Assembly.Load("Store.Core"));

// Add Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IBrandService, BrandService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<StoreDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
