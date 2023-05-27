using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api;

[Route("products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult> Test()
    {
        _logger.LogInformation("Hello");
        return NoContent();
    }
}