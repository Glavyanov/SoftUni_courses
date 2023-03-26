using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data;
using WebShopDemo.Core.Data.Common;
using WebShopDemo.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "My Web Shop",
        Description = "This is the best web shop",
        License = new Microsoft.OpenApi.Models.OpenApiLicense() 
        {
            Name = "EUPL v 1.2"
        }
    });

    c.IncludeXmlComments("WebShopApiDocumentation.xml");
});

builder.Configuration.AddUserSecrets("aspnet-WebShopDemo-F274AD50-FBB7-4413-9D8D-0AC4C8B89766");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDemoDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

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
