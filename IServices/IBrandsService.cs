using HeroTest.ViewModels;

namespace HeroTest.IServices;

public interface IBrandsService
{
    Task<Response<List<BrandViewModel>>> GetBrandListAsync();
}