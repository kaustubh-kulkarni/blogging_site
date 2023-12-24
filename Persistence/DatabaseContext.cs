using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;


//This class is our main entry for DBContext
//We are using EF core for this
public class DatabaseContext : DbContext
{
    //Default CTOR
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    //DbSet for the User class
    public DbSet<User> Users {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users", schema: "public").HasMany( u => u.Blogs).WithOne(b => b.User);
    }
}
