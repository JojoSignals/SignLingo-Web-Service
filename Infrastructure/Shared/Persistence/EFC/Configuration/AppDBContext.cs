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
    

    
}