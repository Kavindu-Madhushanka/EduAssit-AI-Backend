using eduasst_backend.Data;
using eduasst_backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// 🚀 1. React Port එක (5173) සඳහා CORS Policy එකක් මෙතනින් සර්විස් එකට එකතු කරනවා
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // 👈 උඹේ React URL එක
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); // Token/Cookies යවනවා නම් මේක අනිවාර්යයි
        });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapibuilder
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AddDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))
    )
);

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 🚀 2. හදපු CORS Policy එක මෙතනදී ඇප් එකට ඇක්ටිව් කරනවා 
// (❗ අනිවාර්යයෙන්ම UseAuthorization එකට උඩින්ම තියෙන්න ඕනේ)
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();