using System.Data;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DVP.Project.Api.Infrastructure.AutofactModules;
using DVP.Project.Infrastructure;
using Figgle;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Serilog;
using DVP.Project.Api.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MediatorModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new InfrastructureModule()));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder => builder.WithOrigins("http://localhost:4200", "https://localhost:4200", "https://127.0.0.1", "http://127.0.0.1")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


builder.Services.AddSingleton<IDbConnection>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("postgrestDB");
    return new NpgsqlConnection(connectionString);
});

builder.Services.AddDbContext<DVPContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("postgrestDB"))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config => {

    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = false;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
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

app.UseCors("MyPolicy");

app.UseAuthentication();

app.UseAuthorization();

var appName = builder.Configuration.GetSection("AppName").Value;
Console.WriteLine(FiggleFonts.Standard.Render(appName));
Log.Information("Starting web host ({ApplicationContext})...", appName);

app.MapControllers();

app.Run();

