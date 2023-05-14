using Microsoft.EntityFrameworkCore;
using SwaggerApp.Models;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new()
    {
        Version = "V1",
        Title = "Product API",
        Description = "Ürün Ekleme/Silme/Güncelleme iþlemlerini gerçekleþtiren api",
        Contact = new()
        {
            Name = "Musa UYUMAZ",
            Email = "musa.uyumaz73@gmail.com",
            Url = new("www.musauyumaz.com")
        }
    });

    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName()}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    gen.IncludeXmlComments(xmlPath);
});


builder.Services.AddDbContext<SwaggerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
