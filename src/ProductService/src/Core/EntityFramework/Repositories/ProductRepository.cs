using Core.Domain.Entities;
using Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;
    private readonly DataMapper _mapper;

    public ProductRepository(AppDbContext dbContext, DataMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<Product>> Get()
    {
        List<ProductData> productDatas = await _dbContext.Products.ToListAsync();
        return _mapper.MapProducts(productDatas);
    }

    public async Task<Product> GetById(Guid id)
    {
        var data = await _dbContext.Products.FirstAsync(p => p.Id == id.ToString());
        return _mapper.MapProduct(data);
    }

    public async Task Remove(Guid id)
    {
        ProductData productData = await _dbContext.Products.FirstAsync(p => p.Id == id.ToString());
        _dbContext.Remove(productData);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Add(Product product)
    {
        ProductData data = _mapper.MapProduct(product);
        await _dbContext.Products.AddAsync(data);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        ProductData data = _mapper.MapProduct(product);
        _dbContext.Products.Update(data);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Put(Product product)
    {
        string id = product.Id.ToString();
        ProductData? data = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (data is null)
        {
            await Add(product);
        }
        else
        {
            await Update(product);
        }
    }
}