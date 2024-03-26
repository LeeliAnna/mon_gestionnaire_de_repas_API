using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using mon_gestionnaire_de_repas_api.Tools;
using System.Text;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "API Gestionnaire Repas",
            Version = "v1",
        });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "swagger.xml");
    c.IncludeXmlComments(filePath);
});


////Création des différents roles avec le TokenManager
//builder.Services.AddAuthorization(option =>
//{
//    option.AddPolicy("adminPolicy", o => o.RequireRole("admin"));
//    option.AddPolicy("connected", o => o.RequireAuthenticatedUser());
//});


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.Key)),
//        ValidateLifetime = true,
//        ValidateIssuer = false,
//        ValidateAudience = false,
//    };
//});


builder.Services.AddScoped<IngredientService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<IIngredientRepository, IngredientRepository>(sp => new IngredientRepository(builder.Configuration.GetConnectionString("DB_gestionnaire_repas")));
builder.Services.AddScoped<IUserRepository, UserRepository>(sp => new UserRepository(builder.Configuration.GetConnectionString("DB_gestionnaire_repas")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                            policy =>
                            {
                                policy.AllowAnyOrigin()
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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
