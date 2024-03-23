using HeroTest.Extensions;
using HeroTest.IRepositories;
using HeroTest.Models;
using HeroTest.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Repositories;

public class BrandsRepository : IBrandsRepository
{
    private readonly SampleContext _context;

    public BrandsRepository(SampleContext context)
    {
        _context = context;
    }

    public async Task<List<BrandViewModel>> GetBrandListAsync()
    {
        var heroes = await _context.Brands
            .Where(h => h.IsActive == true)
            .Select(h => h.ToViewModel())
            .ToListAsync();
        return heroes;
    }

}
