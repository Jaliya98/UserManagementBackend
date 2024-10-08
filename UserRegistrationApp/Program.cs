using Microsoft.EntityFrameworkCore;
using UserRegistrationApp.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
builder.Services.AddScoped<EMailService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger only in development environment
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Registration API v1");
    });
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

app.UseCors("AllowAll"); // Enable the CORS policy

app.UseStaticFiles(); // Serve static files from wwwroot

app.UseRouting(); // Enable routing

app.UseAuthorization(); // Use authorization if you have authentication logic

app.MapControllers(); // Map controllers to handle API requests

app.Run(); // Start the application
