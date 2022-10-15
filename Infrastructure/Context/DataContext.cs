using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext:DbContext
{
    
    //dbcontext options
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }
    
    public DbSet<Quote> Quotes { get; set; }
}