using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using PasswordManager.API.Data;
using PasswordManager.API.Mappings;
using PasswordManager.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:63422")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


   var mode = true;

    builder.Services.AddDbContext<PasswordsDbContext>(options =>
    {
        if (!mode)
        {
            options.UseInMemoryDatabase("PasswordsDb");
        }
        else
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        }

    });

builder.Services.AddScoped<IPasswordManagerRepository, PSQLPasswordRepository>();

builder.Services.AddAutoMapper(typeof(Mappings));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
