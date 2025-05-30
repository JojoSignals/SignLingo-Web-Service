using Domain.Security.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySQL("server=localhost; user=root; password=admin; database=SignLingo-DB");
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
        builder.Entity<User>().Property(u => u.PhoneNumber).HasMaxLength(15);
        builder.Entity<User>().Property(u => u.Role).IsRequired().HasMaxLength(20);
        builder.Entity<User>().Property(u => u.IsVip).HasDefaultValue(false);
    }
}