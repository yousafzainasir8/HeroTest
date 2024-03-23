using HeroTest.Models;
using HeroTest.ViewModels;

namespace HeroTest.Extensions;

public static class HeroExtensions
{
    public static HeroListViewModel ToHeroList(this Hero entity)
    {
        return new HeroListViewModel()
        {
            Id = entity.Id,
            Name = entity.Name,
            Alias = entity.Alias,
            Brand = entity.Brand.Name
        };
    }

    public static HeroViewModel ToViewModel(this Hero entity)
    {
        return new HeroViewModel()
        {

            Id = entity.Id,
            Name = entity.Name,
            Alias = entity.Alias,
            BrandId = entity.BrandId
        };
    }

    public static Hero ToEntity(this HeroViewModel model)
    {
        return new Hero()
        {

            Id = model.Id,
            Name = model.Name,
            Alias = model.Alias,
            BrandId = model.BrandId
        };
    }
}

