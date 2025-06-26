using Application.ExercisesManager.Features.CommandServices;
using Application.ExercisesManager.Features.QueryServices;
using Application.Security.Features.CommandServices;
using Application.Security.Features.OutboundServices;
using Application.Security.Features.QueryServices;
using Application.Shared.Mapping;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.Exercise;
using Domain.ExercisesManager.Services.IconServices;
using Domain.ExercisesManager.Services.Level;
using Domain.ExercisesManager.Services.Unit;
using Domain.Security.Repositories;
using Domain.Security.Services;
using Domain.Shared.Repository;
using Infrastructure.ExercisesManager.Persistence;
using Infrastructure.Security.Persistence;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

// Dependency Injenction ExercisesManager
//Exercise
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseQueryService, ExerciseQueryService>();
builder.Services.AddScoped<IExerciseCommandService, ExerciseCommandService>();
//QuestionType
builder.Services.AddScoped<IQuestionTypeRepository, QuestionTypeRepository>();
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

builder.Services.AddHttpClient();

//Conexion a MySQL 
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection") ??
                       builder.Configuration.GetConnectionString("signLingoCenterConnection");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTests", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
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

app.UseAuthorization();

app.MapControllers();

app.Run();

// Method to handle database creation
void EnsureDatabaseCreation(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
        Console.WriteLine("AQUI ESTA ENSURE DATA BASE");
        AppDbContextSeed.LoadQuestionType(context);
    }
}