using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Threading.RateLimiting;
using TemplateMarket.API.Filters;
using TemplateMarket.Application.Common.Behaviors;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Common.Services;
using TemplateMarket.Application.Mappings;
using TemplateMarket.Application.UseCases.Products.Commands;
using TemplateMarket.Application.UseCases.Products.Validators;
using TemplateMarket.Infrastructure.Persistence;
using TemplateMarket.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "TemplateMarket API", Version = "v1" });

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Insira o token JWT no formato: Bearer {seu token}",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // frontend local
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Registra os handlers do MediatR
builder.Services.AddMediatR(typeof(CreateProductCommandHandler).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options
      .UseLazyLoadingProxies()                                   // habilita proxy
      .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddRateLimiter(options =>
{
    options.AddPolicy("PublicEndpoints", context =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 2
            }));
});

Console.WriteLine("JWT Issuer: " + builder.Configuration["Jwt:Issuer"]);
Console.WriteLine("JWT Audience: " + builder.Configuration["Jwt:Audience"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Convert.FromBase64String(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpClient(); // para validar o reCAPTCHA
builder.Services.AddScoped<CaptchaService>();

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICacheService, CacheService>();

builder.Services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);

builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);

builder.Services.AddScoped(typeof(IRepository), typeof(Repository));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthCommandEnricherBehavior<,>));

builder.Services.AddScoped<IActiveProfileService, ActiveProfileService>();
builder.Services.AddScoped<RoleFilter>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IEmailNotification, EmailNotification>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddScoped<ActiveProfileValidationMiddleware>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
    options.Filters.Add<ResultResponseFilter>();
    options.Filters.Add<RoleFilter>();
});

var app = builder.Build();

// CORS precisa vir antes de qualquer autenticação
app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ActiveProfileValidationMiddleware>();


app.MapControllers();

app.Run();
