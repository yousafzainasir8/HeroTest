using HeroTest.IRepositories;
using HeroTest.IServices;
using HeroTest.ViewModels;

namespace HeroTest.Services;

public class BrandsService : IBrandsService
{
    private readonly IBrandsRepository _brandsRepository;
    private readonly ILogger<BrandsService> _logger;

    public BrandsService(IBrandsRepository brandsRepository, ILogger<BrandsService> logger)
    {
        _brandsRepository = brandsRepository;
        _logger = logger;
    }

    public async Task<Response<List<BrandViewModel>>> GetBrandListAsync()
    {
        var response = new Response<List<BrandViewModel>>();
        try
        {
            response.Data = await _brandsRepository.GetBrandListAsync();
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