using Api.Views;
using Core.Domain.Entities;
using Core.EntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api;

[Route("products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _repository;
    private readonly ViewMapper _mapper;

    public ProductController(ILogger<ProductController> logger, IProductRepository repository, ViewMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPut]
    public async Task Put([FromBody] ProductView product)
    {
        await _repository.Put(_mapper.MapProduct(product));
    }

    [HttpDelete]
    [Route("id/{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _repository.Remove(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<List<ProductView>> Get()
    {
        List<Product> views = await _repository.Get();
        return _mapper.MapProducts(views);
    }
}