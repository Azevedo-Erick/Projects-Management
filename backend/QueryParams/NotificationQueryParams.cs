using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace ProjectsManagement.QueryParams;

public class NotificationQueryParams: ICustomQueryable
{
    [QueryOperator(Operator = WhereOperator.Equals)]

    public int? RecipientId { get; set; }
    [QueryOperator(Operator = WhereOperator.Equals)]

    public int? TypeId { get; set; }
}