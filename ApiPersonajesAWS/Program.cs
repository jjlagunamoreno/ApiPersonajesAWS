using ApiPersonajesAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Permitimos las Cors
builder.Services.AddCors(p => p.AddPolicy("corsenabled", options =>
{
    options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}
));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
string connectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddTransient<RepositoryPersonajes>();
builder.Services.AddDbContext<PersonajesContext>
    (options => options.UseMySQL(connectionString));
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.MapScalarApiReference();

app.UseCors("corsenabled"); // Permitimos las Cors

app.MapOpenApi();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
