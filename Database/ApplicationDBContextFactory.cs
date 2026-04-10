using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDBContextFactory 
    : IDesignTimeDbContextFactory<ApplicationDBContext>
{
    public ApplicationDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();

        optionsBuilder.UseSqlite("Data Source=app.db");

        return new ApplicationDBContext(optionsBuilder.Options);
    }
}