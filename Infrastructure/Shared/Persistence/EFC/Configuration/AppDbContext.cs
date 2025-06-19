using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Entities;
using Domain.Security.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        
        //Unit
        builder.Entity<Unit>().ToTable("Units");
        builder.Entity<Unit>().HasKey(u => u.Id);
        builder.Entity<Unit>().Property(u=>u.Name).IsRequired().HasMaxLength(50);
        
        //Icon
        builder.Entity<Icon>().ToTable("Icons");
        builder.Entity<Icon>().HasKey(I => I.Id);
        builder.Entity<Icon>().Property(I=>I.UrlImage).HasMaxLength(255);
    }
}