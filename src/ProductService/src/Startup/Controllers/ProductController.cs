using Core.Domain.Entities;
using Core.EntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api;

[Route("products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateProductRequestView request)
    {
        await _repository.Add(new Product(id: 0, name: request.Name, price: request.Price, type: request.Type));
        return NoContent();
    }

    [HttpPost]
    [Route("update")]
    public async Task<ActionResult> Update([FromBody] Product product)
    {
        await _repository.Update(product);
        return NoContent();
    }

    [HttpDelete]
    [Route("id/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.Remove(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<List<Product>> Get()
    {
        List<Product> products = await _repository.Get();
        return products;
    }

    [HttpGet]
    [Route("id/{id}")]
    public async Task<Product> GetById(int id)
    {
        Product product = await _repository.GetById(id);
        return product;
    }
}