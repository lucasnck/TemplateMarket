using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TemplateMarket.API.Filters;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Mappings;
using TemplateMarket.Application.UseCases.Templates.Commands;
using TemplateMarket.Application.UseCases.Templates.Validators;
using TemplateMarket.Infrastructure.Persistence;
using TemplateMarket.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ResultResponseFilter>();
});

// Registra os handlers do MediatR
builder.Services.AddMediatR(typeof(CreateTemplateCommandHandler).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddValidatorsFromAssembly(typeof(CreateTemplateCommandValidator).Assembly);

builder.Services.AddAutoMapper(typeof(TemplateMappingProfile).Assembly);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
