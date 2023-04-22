using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace ProjectsManagement.QueryParams;

public class TagQueryParams : ICustomQueryable
{

    [QueryOperator(Operator = WhereOperator.Contains)]

    public string? Title { get; set; }
    [QueryOperator(Operator = WhereOperator.Equals)]

    public string? HexColor { get; set; }
    public TagQueryParams()
    {
        // constructor logic here
    }

    // class members here
}
