namespace HeroTest.ViewModels;

public class HeroViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Alias { get; set; }
    public int BrandId { get; set; }
}