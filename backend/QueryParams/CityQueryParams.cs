using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace ProjectsManagement.QueryParams;

public class CityQueryParams : ICustomQueryable
{
    [QueryOperator(Operator = WhereOperator.Contains)]
    public string? Name { get; set; }


    [QueryOperator(Operator = WhereOperator.Equals)]
    public int? StateId { get; set; }
    public CityQueryParams()
    {
        // constructor logic here
    }

    // class members here
}
