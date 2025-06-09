using TemplateMarket.API.Configurations;
using TemplateMarket.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddJwtAuthentication(builder.Configuration)
    .AddSwaggerDocumentation()
    .AddRateLimitingPolicies()
    .AddApplicationServices(builder.Configuration)
    .AddApiMiddlewares()
    .AddCors(options =>
    {
        options.AddPolicy("AllowFrontend", policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
    });

var app = builder.Build();

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<ActiveProfileValidationMiddleware>();
app.MapControllers();
app.Run();
