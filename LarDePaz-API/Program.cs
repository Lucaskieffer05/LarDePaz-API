using System.Security.Claims;
using System.Text;
using LarDePaz_API.DAL.DB;
using LarDePaz_API.DAL.Seeding;
using LarDePaz_API.Models.Constants;
using LarDePaz_API.Security;
using LarDePaz_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("APIContextConnection") ?? throw new InvalidOperationException("Connection string 'APIContextConnection' not found.");


// Add services to the container.
ServiceContainer.AddServices(builder.Services);
builder.Services.AddScoped<ISeeder, Seeder>();


// Add Entity Framework service
builder.Services.AddDbContextFactory<APIContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Roles authorization
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAuthorizationHandler, RolesHandler>();

// Configure JWT authentication
var key = builder.Configuration["JWT:Key"];
if (string.IsNullOrEmpty(key))
    throw new InvalidOperationException("JWT key not found.");


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(Policies.Admin, policy => policy.Requirements.Add(new AuthorizeRolesAttribute(Roles.ADMIN)))
    .AddPolicy(Policies.Employee, policy => policy.Requirements.Add(new AuthorizeRolesAttribute(Roles.EMPLOYEE)));

var app = builder.Build();

//builder.Services.AddOpenApi();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}*/

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


await Seed();


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task Seed()
{
    using var scope = app.Services.CreateScope();
    var dbSeeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
    await dbSeeder.Seed();
}