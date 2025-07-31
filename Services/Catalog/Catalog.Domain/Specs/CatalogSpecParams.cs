namespace Catalog.Core.Specs;

public class CatalogSpecParams
{
    private const int MaxPageSize = 70;
    
    private int _pageSize = 10;
    
    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    
    public int PageIndex { get; init; } = 1;
    
    public string? BrandId { get; init; }
    
    public string? TypeId { get; init; }
    
    public string? Sort { get; init; }
    
    public string? Search{ get; init; }
}