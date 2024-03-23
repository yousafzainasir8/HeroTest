using HeroTest.Extensions;
using HeroTest.IRepositories;
using HeroTest.Models;
using HeroTest.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Repositories;

public class HeroesRepository : IHeroesRepository
{
    private readonly SampleContext _context;

    public HeroesRepository(SampleContext context)
    {
        _context = context;
    }

    public async Task<List<HeroListViewModel>> GetHeroesForListViewAsync()
    {
        var heroes = await _context.Heroes
            .Include(h => h.Brand)
            .Where(h => h.IsActive == true)
            .Select(h => h.ToHeroList())
            .ToListAsync();
        return heroes;
    }
    public async Task<bool> AddHeroAsync(Hero newHero)
    {
        newHero.CreatedOn = DateTime.UtcNow;
        newHero.UpdatedOn = DateTime.UtcNow;
        newHero.IsActive = true;
        _context.Heroes.Add(newHero);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateHeroAsync(Hero updatedHero)
    {
        var hero = await _context.Heroes.FindAsync(updatedHero.Id);
        if (hero == null)
        {
            return false;
        }

        hero.Name = updatedHero.Name;
        hero.Alias = updatedHero.Alias;
        hero.BrandId = updatedHero.BrandId;
        hero.UpdatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<HeroViewModel?> GetHeroByIdAsync(int heroId)
    {
        return await _context.Heroes
            .Include(h => h.Brand)
            .Where(h => h.Id == heroId && h.IsActive == true)
            .Select(h => h.ToViewModel()).FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteHeroAsync(int heroId)
    {
        var hero = await _context.Heroes.FindAsync(heroId);
        if (hero == null)
        {
            return false;
        }

        hero.IsActive = false;
        hero.UpdatedOn = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
}

