using Microsoft.EntityFrameworkCore;
using Receitas.Data;
using Receitas.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ReceitasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories
builder.Services.AddScoped<IReceitaRepository, ReceitaRepository>();
builder.Services.AddScoped<IIngredienteRepository, IngredienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Receitas V1");
        c.RoutePrefix = string.Empty; // This will make Swagger UI available at the app's root (http://localhost:<port>/)
    });
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();