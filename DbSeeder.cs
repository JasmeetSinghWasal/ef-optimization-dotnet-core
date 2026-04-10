using Microsoft.EntityFrameworkCore;
public static class DbSeeder
{
    public static async Task SeedProducts(ApplicationDBContext context)
    {
        Console.WriteLine("Seeding products...");
        if (await context.Products.AnyAsync())
        {
            Console.WriteLine("Products already exist in the database. Skipping seeding.");
            return;
        }
            
        var products = new List<Product>();

        for (int i = 1; i <= 500; i++)
        {
            products.Add(new Product
            {
                Name = $"Product {i}",
                Price = Random.Shared.Next(10, 1000)
            });
        }

        context.Products.AddRange(products);
        Console.WriteLine("Saving products to the database...");
        await context.SaveChangesAsync();
    }
}