using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.BusinessAreas.Users.Queries.GetUsersWithPagination
{
    public class GetUsersWithPaginationQuery : IRequest<Result<List<User>>>
    {
        public string? SearchTerm { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
