using Gandalf.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Gandalf.Backend.Services;

public class ProductService(IDbContextFactory<GandalfDbContext> dbContextFactory)
{
    public List<Product> GetProducts()
    {
        using var context = dbContextFactory.CreateDbContext();

        return context.Products.ToList();        
    }

    public void CreateProduct(Product product)
    {
        using var context = dbContextFactory.CreateDbContext();

        context.Products.Add(new Product { Name = product.Name, Description = product.Description, CategoryId = product.CategoryId , ImageLink = product.ImageLink});

        context.SaveChanges();
    }

    public void Update(Product product)
    {
        using var context = dbContextFactory.CreateDbContext();

        context.Products.Update(product);

        context.SaveChanges();
    }

    public Product? GetProduct(int? id)
    {
        using var context = dbContextFactory.CreateDbContext();

        return context.Products.FirstOrDefault(m => m.Id == id);
    }

    public Product? DeleteProduct(int? id)
    {
        using var context = dbContextFactory.CreateDbContext();

        var product = context.Products.FirstOrDefault(m => m.Id == id);

        if (product is null)
            return default;

        context.Products.Remove(product);
        context.SaveChanges();

        return product;
    }
}
