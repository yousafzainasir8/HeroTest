using HeroTest.IServices;
using HeroTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers;


[ApiController]
[Route("[controller]")]
public class BrandsController : ControllerBase
{
    private readonly ILogger<BrandsController> _logger;
    private readonly IBrandsService _brandsService;
    public BrandsController(IBrandsService brandsService, ILogger<BrandsController> logger)
    {
        _logger = logger;
        _brandsService = brandsService;
    }

    [HttpGet]
    public async Task<Response<List<BrandViewModel>>> GetBrandListAsync()
    {
        return await _brandsService.GetBrandListAsync();
    }

}

