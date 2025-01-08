using Core.ElasticSearch;
using Core.Security;
using Core.Security.Encryption;
using Core.Security.JWT;
using ECommerce.Application;
using ECommerce.Infrastracture;
using ECommerce.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");
builder.Services.AddApplicationServiceDependencies();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddSecurityServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddIInfrastructureDependencies(builder.Configuration);
builder.Services.AddElasticSearchDependencies(builder.Configuration);

const string tokenOptionsConfigurationName = "TokenOptions";
TokenOptions tokenOptions = builder.Configuration.GetSection(tokenOptionsConfigurationName).Get<TokenOptions>()
    ?? throw new InvalidOperationException(
        $"{tokenOptionsConfigurationName} section is missing in the configuration file.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
