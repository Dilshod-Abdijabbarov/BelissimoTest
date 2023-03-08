using DatabaseContext;
using Domian.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.DTOs.Users;
using Services.Mappers;
using System.Text;
using TestAPI.Extensions;
using TestAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddDbContext<BelissimoDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc(name:"v1",new OpenApiInfo {Title = "WebAPI", Version = "v1"});
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter like Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
               Reference=new OpenApiReference
               {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer",
               },
            },
            Array.Empty<string>()
        },
    });
});

IConfigurationSection appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);
AppSettings appSettings = appSettingSection.Get<AppSettings>();
var secrutKey = Encoding.ASCII.GetBytes(appSettings.SecretKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secrutKey),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

builder.Services.AddCustomerService();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
