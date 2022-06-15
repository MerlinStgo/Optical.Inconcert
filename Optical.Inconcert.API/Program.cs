using Microsoft.OpenApi.Models;
using Optical.Inconcert.API;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "INCONCERT WIN",
        Description = "Mostrar infomación requerida para INCONCERT API",
        //TermsOfService = new Uri("https://pragimtech.com"),
        Contact = new OpenApiContact
        {
            Name = "Área TI",
            Email = "desarrolloti@optical.com",
            Url = new Uri("https://www.optical.pe/"),
        },
        License = new OpenApiLicense
        {
            Name = "© Optical Network",
            Url = new Uri("https://www.optical.pe/"),
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
