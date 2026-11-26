using Apex.Catering.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  // Register controllers with the framework
builder.Services.AddOpenApi();      // Register OpenAPI/Swagger services

// Register database context with the framework
builder.Services.AddDbContext<BookingsDbContext>();
// Add the DbTestInitializer as a scoped service
builder.Services.AddScoped<DbTestDataInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Caterting.Api v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


