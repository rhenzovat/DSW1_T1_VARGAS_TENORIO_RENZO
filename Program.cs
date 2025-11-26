using Microsoft.EntityFrameworkCore;
using DSW1_T1_VARGAS_TENORIO_RENZO.Data;
using DotNetEnv;
using System.Text.Json.Serialization;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// VARIABLES ENTORNO
var server = Environment.GetEnvironmentVariable("MYSQL_SERVER");
var port = Environment.GetEnvironmentVariable("MYSQL_PORT");
var database = Environment.GetEnvironmentVariable("MYSQL_DATABASE");
var user = Environment.GetEnvironmentVariable("MYSQL_USER");
var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");

var connectionString = $"Server={server};Port={port};Database={database};User={user};Password={password}";

// DB CONTEXT
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// REPOS
builder.Services.AddScoped<CursoRepository>();
builder.Services.AddScoped<NivelAcademicoRepository>();

// SWAGGER
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirTodo");

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
