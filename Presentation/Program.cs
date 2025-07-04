using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.ExercisesManager.Features.CommandServices;
using Application.ExercisesManager.Features.QueryServices;
using Application.Security.ACL;
using Application.Security.Features.CommandServices;
using Application.Security.Features.OutboundServices;
using Application.Security.Features.QueryServices;
using Application.Shared.Features.OutboundServices.ACL;
using Application.Shared.Mapping;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.Exercise;
using Domain.ExercisesManager.Services.ExerciseOption;
using Domain.ExercisesManager.Services.IconServices;
using Domain.ExercisesManager.Services.Level;
using Domain.ExercisesManager.Services.Option;
using Domain.ExercisesManager.Services.Unit;
using Domain.Security.Repositories;
using Domain.Security.Services;
using Domain.Shared.Repository;
using Domain.Shared.Services;
using Infrastructure.ExercisesManager.Persistence;
using Infrastructure.Security.Persistence;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Infrastructure.Shared.Services.CloudinaryImageService;
using Microsoft.EntityFrameworkCore;
using Application.UserStats.Features.CommandServices;
using Application.UserStats.Features.QueryServices;
using Domain.UserStats.Repositories;
using Domain.UserStats.Services;
using Infrastructure.UserStats.Persistence;
using Microsoft.IdentityModel.Tokens;
using Presentation.Security.ACL;
using Presentation.Shared.ACL;
using Presentation.Shared.ASP.Configuration;
using Application.UserStats.ACL;
using Presentation.UserStats.ACL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
    options.Conventions.Add(new PrefixVersioningNamingConvention("api/v1"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(RequestToModel),
    typeof(ModelToResponse));
//Dependency Injection Native
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEncryptService, EncryptService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGoogleCaptchaService, GoogleCaptchaService>();
builder.Services.AddScoped<ISecurityContextFacade, SecurityContextFacade>();


// Dependency Injenction ExercisesManager
//Exercise
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseQueryService, ExerciseQueryService>();
builder.Services.AddScoped<IExerciseCommandService, ExerciseCommandService>();
//QuestionType
builder.Services.AddScoped<IQuestionTypeRepository, QuestionTypeRepository>();
// ExerciseOptions
builder.Services.AddScoped<IExerciseOptionRepository, ExerciseOptionRepository>();
builder.Services.AddScoped<IExerciseOptionQueryService, ExerciseOptionQueryService>();

//Unit
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<IUnitQueryService, UnitQueryService>();
builder.Services.AddScoped<IUnitCommandService, UnitCommandService>();
//Icon
builder.Services.AddScoped<IIconRepository, IconRepository>();
builder.Services.AddScoped<IIconQueryService, IconQueryService>();
builder.Services.AddScoped<IIconCommandService, IconCommandService>();
//Level
builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<ILevelQueryService, LevelQueryService>();
builder.Services.AddScoped<ILevelCommandService, LevelCommandService>();
//Option
builder.Services.AddScoped<IOptionRepository, OptionRepository>();
builder.Services.AddScoped<IOptionQueryService, OptionQueryService>();
builder.Services.AddScoped<IOptionCommandService, OptionCommandService>();

// DI Shared 
builder.Services.Configure<CloudinaryCredentials>(builder.Configuration.GetSection("Cloudinary"));
builder.Services.AddScoped<IImageManagerService, ImageManagerService>();
builder.Services.AddScoped<IExternalSecurityService, ExternalSecurityService>();


// Dependency Injection UserStats
builder.Services.AddScoped<IUserStatsRepository, UserStatRepository>();
builder.Services.AddScoped<IUserStatsCommandService, UserStatCommandService>();
builder.Services.AddScoped<IUserStatsQueryService, UserStatQueryService>();
builder.Services.AddScoped<IUserStatsQueryService, UserStatQueryService>();
builder.Services.AddScoped<IUserStatContextFacade, UserStatContextFacade>();
builder.Services.AddScoped<IUserStatContextService, UserStatContextService>();


builder.Services.AddHttpClient();

//Conexion a MySQL 
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection") ??
                       builder.Configuration.GetConnectionString("signLingoCenterConnection");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTests", policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
    {
        options.UseMySQL(connectionString, mysqlOptions =>
        {
            mysqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: null);
        });

        if (builder.Environment.IsDevelopment())
        {
            options
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
        else if (builder.Environment.IsProduction())
        {
            options
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        }
    }
});
builder.Services.AddHttpContextAccessor();

var jwtConfig = builder.Configuration.GetSection("Auth");
var secretKey = jwtConfig["SecretKey"];


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),

        ValidateIssuer = false,
        ValidateAudience = false,

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your token in the text input.\r\n\r\nExample: \"Bearer abc123\""
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.UseCors("AllowTests");
//DB-Ensure Creation
EnsureDatabaseCreation(app);


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

// Method to handle database creation
void EnsureDatabaseCreation(WebApplication appArgs)
{
    var scope = appArgs.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    AppDbContextSeed.LoadQuestionType(context);
}