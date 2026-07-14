using eduasst_backend.Data;
using eduasst_backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") 
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); 
        });
});

// https://aka.ms/aspnet/openapibuilder
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AddDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))
    )
);

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IFolderLessonNotesRepository, FolderLessonNotesRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();