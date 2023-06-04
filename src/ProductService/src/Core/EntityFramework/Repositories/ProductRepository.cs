using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework.Repositories;

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

    public async Task<Product> GetById(int id)
    {
        return await _dbContext.Products.FirstAsync(p => p.Id == id);
    }

    public async Task<Product> GetByName(string name)
    {
        return await _dbContext.Products.FirstAsync(p => p.Name == name);
    }

    public async Task Remove(int id)
    {
        _dbContext.Remove(await GetById(id));
        await _dbContext.SaveChangesAsync();
    }

    public async Task Add(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }
}