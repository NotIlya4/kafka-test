using Core.Domain;
using Core.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> Get()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task CreateProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateProduct(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveProduct(int productId)
    {
        Product product = await _dbContext.Products.FirstAsync(p => p.Id == productId);
        _dbContext.Products.Remove(product);
    }
}