using Core.Domain.Entities;
using Core.EntityFramework.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api;

[Route("products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateProductRequest request)
    {
        await _service.Add(request);
        return NoContent();
    }

    [HttpPost]
    [Route("update")]
    public async Task<ActionResult> Update([FromBody] Product product)
    {
        await _service.Update(product);
        return NoContent();
    }

    [HttpDelete]
    [Route("id/{id}")]
    public async Task<ActionResult> Remove(int id)
    {
        await _service.Remove(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<List<Product>> Get()
    {
        return await _service.Get();
    }

    [HttpGet]
    [Route("id/{id}")]
    public async Task<Product> GetById(int id)
    {
        Product product = await _service.GetById(id);
        return product;
    }
}