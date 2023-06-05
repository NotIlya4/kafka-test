using Core.Domain;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Startup.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<List<Product>> Get()
    {
        return await _repository.Get();
    }
}