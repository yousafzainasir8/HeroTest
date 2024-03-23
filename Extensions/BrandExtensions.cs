using HeroTest.Models;
using HeroTest.ViewModels;

namespace HeroTest.Extensions;

public static class BrandExtensions
{
    public static BrandViewModel ToViewModel(this Brand brand)
    {
        return new BrandViewModel
        {
            Id = brand.Id,
            Name = brand.Name,
        };
    }
}

