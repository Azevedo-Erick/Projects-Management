using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace ProjectsManagement.Models;

public class StateQueryParams : ICustomQueryable
{

    [QueryOperator(Operator = WhereOperator.Contains)]
    public string? Name { get; set; }


    [QueryOperator(Operator = WhereOperator.Equals)]
    public int? CountryId { get; set; }
}