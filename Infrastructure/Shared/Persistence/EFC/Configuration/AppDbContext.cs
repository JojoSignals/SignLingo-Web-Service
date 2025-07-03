using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Security.Model.Entities;
using Infrastructure.Shared.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.EntityFrameworkCore.Extensions;

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
    public DbSet<Option> Options { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<ExerciseOption> ExerciseOptions { get; set; }

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

        // Exercise
        builder.Entity<Exercise>().ToTable("Exercise");
        builder.Entity<Exercise>().HasKey(ex => ex.Id);
        // builder.Entity<Exercise>().Property(ex => ex.Id).UseMySQLAutoIncrementColumn();
        builder.Entity<Exercise>().HasIndex(ex => ex.QuestionTypeId);

        // Exercises --- Levels
        builder.Entity<Exercise>()
            .HasOne(e => e.Level)
            .WithMany(n => n.Exercises)
            .HasForeignKey(n => n.LevelId);

        // Option
        builder.Entity<Option>().ToTable("Option");
        builder.Entity<Option>().HasKey(op => op.Id);
        builder.Entity<Option>().Property(op => op.Word).IsRequired().HasMaxLength(20);
        builder.Entity<Option>().Property(op => op.UrlImage);

        //ExerciseOption
        builder.Entity<ExerciseOption>().ToTable("ExerciseOption");
        // builder.Entity<ExerciseOption>().HasKey(eo => new { eo.ExerciseId, eo.OptionId });
        builder.Entity<ExerciseOption>().HasKey(eo => eo.Id);
        builder.Entity<ExerciseOption>().Property(eo => eo.IsCorrect).HasDefaultValue(false);
        //ExericseOption Relations
        builder.Entity<ExerciseOption>()
            .HasOne(eo => eo.Exercise)
            .WithMany(e => e.ExerciseOptions)
            .HasForeignKey(eo => eo.ExerciseId);

        builder.Entity<ExerciseOption>()
            .HasOne(eo => eo.Option)
            .WithMany(o => o.ExerciseOptions)
            .HasForeignKey(eo => eo.OptionId);

        //QuestionType
        builder.Entity<QuestionTypeEntity>().ToTable("QuestionTypes");
        builder.Entity<QuestionTypeEntity>().HasKey(q => q.Id);
        builder.Entity<QuestionTypeEntity>().Property(q => q.Qtype).HasMaxLength(20).IsRequired()
            .HasConversion<string>();

        //Exercise || QuestionType
        builder.Entity<Exercise>()
            .HasOne(ex => ex.QuestionType)
            .WithMany(q => q.Exercise)
            .HasForeignKey(e => e.QuestionTypeId);

        //Unit
        builder.Entity<Unit>().ToTable("Units");
        builder.Entity<Unit>().HasKey(u => u.Id);
        builder.Entity<Unit>().Property(u => u.Name).IsRequired().HasMaxLength(50);

        //Icon
        builder.Entity<Icon>().ToTable("Icons");
        builder.Entity<Icon>().HasKey(I => I.Id);
        builder.Entity<Icon>().Property(I => I.UrlImage).HasMaxLength(255);

        //Level
        builder.Entity<Level>().ToTable("Levels");
        builder.Entity<Level>().HasKey(l => l.Id);
        builder.Entity<Level>().Property(l => l.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Level>().Property(l => l.ExperienceRequired).IsRequired().HasDefaultValue(0);
        builder.Entity<Level>().Property(l => l.UnitId).IsRequired().HasDefaultValue(0);
        builder.Entity<Level>().Property(l => l.IconId).IsRequired().HasDefaultValue(0);

        //Level --- Unit 
        builder.Entity<Level>()
            .HasOne(n => n.Unit)
            .WithMany(u => u.Levels)
            .HasForeignKey(n => n.UnitId);


        //Level --- Icon
        builder.Entity<Level>()
            .HasOne(l => l.Icon)
            .WithMany(i => i.Levels)
            .HasForeignKey(l => l.IconId);


        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}