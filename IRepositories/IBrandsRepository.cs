using HeroTest.ViewModels;

namespace HeroTest.IRepositories;

public interface IBrandsRepository
{
    Task<List<BrandViewModel>> GetBrandListAsync();
}
