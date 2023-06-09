using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace ProjectsManagement.QueryParams;

public class PersonQueryParams : ICustomQueryable
{
    [QueryOperator(Operator = WhereOperator.Contains)]

    public string? Name { get; set; }
    [QueryOperator(Operator = WhereOperator.Contains)]

    public string? Email { get; set; }

    public PersonQueryParams()
    {
        // constructor logic here
    }

    // class members here
}
