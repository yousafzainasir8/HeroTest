using HeroTest.Models;
using HeroTest.ViewModels;

namespace HeroTest.IServices;

public interface IHeroesService
{
    Task<Response<List<HeroListViewModel>>> GetHeroesForListViewAsync();
    Task<Response<bool>> DeleteHeroAsync(int heroId);
    Task<Response<bool>> AddHeroAsync(HeroViewModel newHero);
    Task<Response<bool>> UpdateHeroAsync(HeroViewModel updateHero);
    Task<Response<HeroViewModel>> GetHeroByIdAsync(int heroId);
}
