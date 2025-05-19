using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Core.Interfaces;
using Services.Core.Services;
using Services.Infraestructure.Data;
using Services.Infraestructure.Mappings;
using Services.Infraestructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
    };
});



builder.Services.AddDbContext<PruebaTecnicaAportesEnLineaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("bd"))
                );

builder.Services.AddScoped<IDepartamentService, DepartamentService>();
builder.Services.AddScoped(typeof(IDepartamentRepository), typeof(DepartmentRepository));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
builder.Services.AddScoped<ISalaryCalculator, SalaryCalculator>();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddMvc(options =>
{

}).AddFluentValidation(options =>
options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            );


//Cuando se presente el error de referencia cirular simplemente ignorelo, ese error
builder.Services.AddControllers(options =>
{
    //options.Filters.Add<GlobalExceptionFilter>();
}
).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

