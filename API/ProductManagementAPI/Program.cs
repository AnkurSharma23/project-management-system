using System.Reflection;
using API.ProductManagementAPI.Application.Common.Interface;
using API.ProductManagementAPI.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

// Adding loggin for the app

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
    config.AddConfiguration(builder.Configuration.GetSection("Logging"));
    config.AddSimpleConsole(i => i.ColorBehavior = LoggerColorBehavior.Enabled);
}).CreateLogger("Program");

// Add services to the container.

// This will be refined further for the products UI app to allow only the localhost and the hosted url environment

builder.Services.AddCors(options => options.AddPolicy(name: "webOrigins", builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemory"));
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Adding security headers for the API
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Remove("Remote Address");
    context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
    context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
    context.Response.Headers.Remove("X-Powered-By");
    context.Response.Headers.Remove("x-aspnet-version");
    context.Response.Headers.Add("Content-Security-Policy",
        "default-src 'self';" +
        "script-src 'self' data: 'unsafe-inline';" +
        "connect-src * data: blob: filesystem:; " +
        "style-src 'self' data: 'unsafe-inline'" +
        "img-src 'self' data:;" +
        "frame-src 'self' data:;" +
        "font-src 'self' data:;" +
        "object-src 'none';" +
        "media-src * data: blob: filesystem:;");

    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
