using FacilitaCondo.API.Extensions;
using FacilitaCondo.Application.Interfaces;
using FacilitaCondo.Application.Interfaces.RegisterTenant;
using FacilitaCondo.Application.UseCases;
using FacilitaCondo.Domain.Repository;
using FacilitaCondo.Infrastructure.Context;
using FacilitaCondo.Infrastructure.Repositories;
using FacilitaCondo.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Carregar configurações do appsettings.json
var configuration = builder.Configuration;

// Obter a chave JWT do arquivo de configuração
var jwtKey = configuration["Jwt:Key"];

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configurar Swagger com suporte para autenticação JWT
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Insira o token JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// MediatR
builder.Services.AddMediatRApi();

var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(defaultConnectionString);
builder.Services.AddDbContext<FacilitaCondoContext>(options =>
    options.UseNpgsql(defaultConnectionString));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Other services
builder.Services.AddSingleton<EmailService>();

// DI - Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

// DI - UseCases
builder.Services.AddScoped<IRegisterCondominiumManagerUseCase, RegisterCondominiumManagerUseCase>();
builder.Services.AddScoped<IRegisterOwnerUseCase, RegisterOwnerUseCase>();
builder.Services.AddScoped<IRegisterTenantUseCase, RegisterTenantUseCase>();
builder.Services.AddScoped<IRegisterCondominiumUseCase, RegisterCondominiumUseCase>();
builder.Services.AddScoped<IGetAccessTokenUseCase, GetAccessTokenUseCase>();
builder.Services.AddScoped<IGetValidTemporaryTokenUseCase, GetValidTemporaryTokenUseCase>();
builder.Services.AddScoped<ISendTemporaryTokenToEmailUseCase, SendTemporaryTokenToEmailUseCase>();

// Configurar a autenticação JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();