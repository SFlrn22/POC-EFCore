namespace EFCorePOC.Domain;

public class FilterModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public IEnumerable<Filter>? Filters { get; set; } = [];
}

public class Filter
{
    public string FilterName { get; set; } = string.Empty;
    public string FilterValue { get; set; } = string.Empty;
    public string Relation { get; set; } = string.Empty;
}