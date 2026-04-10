using Microsoft.EntityFrameworkCore;
public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

//EntityFramework will translate this into SQL table
    public DbSet<Product> Products { get; set; }
}