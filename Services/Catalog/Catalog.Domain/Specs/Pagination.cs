namespace Catalog.Core.Specs;

public class Pagination<T> where T : class
{
    public required int PageIndex { get; init; }
    
    public required int PageSize { get; init; }
    
    public required long Count { get; init; }

    public required IReadOnlyList<T> Data { get; init; }
}