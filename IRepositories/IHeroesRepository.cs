using HeroTest.Models;
using HeroTest.ViewModels;

namespace HeroTest.IRepositories;

public interface IHeroesRepository
{
    Task<List<HeroListViewModel>> GetHeroesForListViewAsync();
    Task<bool> AddHeroAsync(Hero newHero);
    Task<bool> UpdateHeroAsync(Hero updateHero);
    Task<HeroViewModel?> GetHeroByIdAsync(int heroId);
    Task<bool> DeleteHeroAsync(int heroId);
}

