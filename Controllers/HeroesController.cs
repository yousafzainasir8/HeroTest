using HeroTest.IServices;
using HeroTest.Models;
using HeroTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{

    private readonly ILogger<HeroesController> _logger;
    private readonly IHeroesService _heroService;
    public HeroesController(IHeroesService heroService, ILogger<HeroesController> logger)
    {
        _logger = logger;
        _heroService = heroService;
    }

    [HttpGet]
    public async Task<Response<List<HeroListViewModel>>> GetHeroesForListViewAsync()
    {
        return await _heroService.GetHeroesForListViewAsync();
    }

    [HttpDelete("{heroId}")]
    public async Task<Response<bool>> DeleteHeroAsync([FromRoute] int heroId)
    {
        return await _heroService.DeleteHeroAsync(heroId);
    }

    [HttpPost]
    public async Task<Response<bool>> AddHeroAsync([FromBody] HeroViewModel newHero)
    {
        return await _heroService.AddHeroAsync(newHero);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateHeroAsync([FromBody] HeroViewModel updateHero)
    {
        return await _heroService.AddHeroAsync(updateHero);
    }

    [HttpGet("{heroId}")]
    public async Task<Response<HeroViewModel>> GetHeroByIdAsync([FromRoute] int heroId)
    {
        return await _heroService.GetHeroByIdAsync(heroId);
    }

}

