using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Security.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.UserStats.Model.Agreggates;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Icon> Icons { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<UserStat> UserStats { get; set; }

    public DbSet<QuestionTypeEntity> QuestionTypes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("signLingoCenterConnection"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // FLuent API
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
        builder.Entity<User>().Property(u => u.ProfilePictureUrl).HasMaxLength(255);
        builder.Entity<User>().Property(u => u.Role).IsRequired().HasMaxLength(20);
        builder.Entity<User>().Property(u => u.IsVip).HasDefaultValue(false);
        
        //Exercise
        builder.Entity<Exercise>().ToTable("Exercises");
        builder.Entity<Exercise>().HasKey(ex => ex.Id);
        builder.Entity<Exercise>().Property(ex => ex.QuestionWord).HasMaxLength(50);
        builder.Entity<Exercise>().HasIndex(ex => ex.QuestionTypeId).IsUnique();
        
        // Ejercicios --- Level
        builder.Entity<Exercise>()
            .HasOne(e => e.Level)
            .WithMany(n => n.Exercises)
            .HasForeignKey(n => n.LevelId);
        
        //QuestionType
        builder.Entity<QuestionTypeEntity>().ToTable("QuestionTypes");
        builder.Entity<QuestionTypeEntity>().HasKey(q => q.Id);
        builder.Entity<QuestionTypeEntity>().Property(q => q.Qtype).HasMaxLength(20).IsRequired().HasConversion<string>();
        
        //Exercise || QuestionType
        builder.Entity<Exercise>()
            .HasOne(ex => ex.QuestionType)
            .WithOne(q => q.Exercise)
            .HasForeignKey<Exercise>(e => e.QuestionTypeId);
        
        //Unit
        builder.Entity<Unit>().ToTable("Units");
        builder.Entity<Unit>().HasKey(u => u.Id);
        builder.Entity<Unit>().Property(u=>u.Name).IsRequired().HasMaxLength(50);
        
        //Icon
        builder.Entity<Icon>().ToTable("Icons");
        builder.Entity<Icon>().HasKey(I => I.Id);
        builder.Entity<Icon>().Property(I=>I.UrlImage).HasMaxLength(255);
        
        //Level
        builder.Entity<Level>().ToTable("Levels");
        builder.Entity<Level>().HasKey(l => l.Id);
        builder.Entity<Level>().Property(l => l.LevelName).IsRequired().HasMaxLength(50);
        builder.Entity<Level>().Property(l => l.LevelDescription).IsRequired().HasMaxLength(100);
        builder.Entity<Level>().Property(l=>l.ExperienceRequiered).IsRequired().HasDefaultValue(0);
        builder.Entity<Level>().Property(l=>l.TotalQuestions).IsRequired().HasDefaultValue(0);
        builder.Entity<Level>().Property(l=>l.UnitId).IsRequired().HasDefaultValue(0);
        builder.Entity<Level>().Property(l=>l.IconId).IsRequired().HasDefaultValue(0);
        
        //Level --- Unit 
        builder.Entity<Level>()
            .HasOne(n => n.Unit)
            .WithMany(u => u.Levels)
            .HasForeignKey(n => n.UnitId);
            
        
        //Level --- Icon
        builder.Entity<Level>()
            .HasOne(l => l.Icon)
            .WithOne(i => i.Level)
            .HasForeignKey<Level>(l => l.IconId);
        
  
        //UserStats
        builder.Entity<UserStat>().ToTable("UserStats");
        builder.Entity<UserStat>().HasKey(us => us.Id);
        builder.Entity<UserStat>().Property(us => us.Lives).IsRequired();
        builder.Entity<UserStat>().Property(us => us.Stars).IsRequired();
        builder.Entity<UserStat>().Property(us => us.TotalLivesLost).IsRequired();
        builder.Entity<UserStat>().Property(us => us.TotalAdsWatched).IsRequired();
        builder.Entity<UserStat>().Property(us => us.QuestionsComplete).IsRequired();
        builder.Entity<UserStat>().Property(us => us.UserId).IsRequired();

    }
}