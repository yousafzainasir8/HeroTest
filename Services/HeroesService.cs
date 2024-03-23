using HeroTest.Controllers;
using HeroTest.Extensions;
using HeroTest.IRepositories;
using HeroTest.IServices;
using HeroTest.ViewModels;

namespace HeroTest.Services;

public class HeroesService : IHeroesService
{
    private readonly IHeroesRepository _heroRepository;
    private readonly ILogger<HeroesService> _logger;

    public HeroesService(IHeroesRepository heroRepository, ILogger<HeroesService> logger)
    {
        _heroRepository = heroRepository;
        _logger = logger;
    }

    public async Task<Response<List<HeroListViewModel>>> GetHeroesForListViewAsync()
    {
        var response = new Response<List<HeroListViewModel>>();
        try
        {
            response.Data = await _heroRepository.GetHeroesForListViewAsync();
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex, $"An error occurred in {GetType().Name}. Error: {ex.Message}", ex.Message);
        }
        return response;
    }

    public async Task<Response<bool>> DeleteHeroAsync(int heroId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _heroRepository.DeleteHeroAsync(heroId);
            if (!response.Data)
            {
                response.IsSuccess = false;
                response.Message = $"Hero with ID {heroId} not found.";
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex, $"An error occurred in {GetType().Name}. Error: {ex.Message}", ex.Message);
        }
        return response;
    }

    public async Task<Response<bool>> AddHeroAsync(HeroViewModel newHero)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _heroRepository.AddHeroAsync(newHero.ToEntity());
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex, $"An error occurred in {GetType().Name}. Error: {ex.Message}", ex.Message);
        }
        return response;
    }

    public async Task<Response<bool>> UpdateHeroAsync(HeroViewModel updateHero)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _heroRepository.UpdateHeroAsync(updateHero.ToEntity());
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex, $"An error occurred in {GetType().Name}. Error: {ex.Message}", ex.Message);
        }
        return response;
    }

    public async Task<Response<HeroViewModel>> GetHeroByIdAsync(int heroId)
    {
        var response = new Response<HeroViewModel>();
        try
        {
            response.Data = await _heroRepository.GetHeroByIdAsync(heroId);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex, $"An error occurred in {GetType().Name}. Error: {ex.Message}", ex.Message);
        }
        return response;
    }
}

