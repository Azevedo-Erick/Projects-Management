using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace ProjectsManagement.QueryParams;

public class ActivityLogQueryParams: ICustomQueryable
{
    [QueryOperator(Operator = WhereOperator.Equals)]
    public int? PersonId { get; set; }
    [QueryOperator(Operator = WhereOperator.Equals)]
    public int? ActivityTypeId { get; set; }
}