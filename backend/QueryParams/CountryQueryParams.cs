using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace ProjectsManagement.QueryParams;

public class CountryQueryParams : ICustomQueryable
{
    [QueryOperator(Operator = WhereOperator.Contains)]
    public string? Name { get; set; }


}
