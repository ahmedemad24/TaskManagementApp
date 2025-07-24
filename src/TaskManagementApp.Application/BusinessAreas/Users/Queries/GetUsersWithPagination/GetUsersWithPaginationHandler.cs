using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Application.Interfaces.Persistence;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.BusinessAreas.Users.Queries.GetUsersWithPagination
{
    public class GetUsersWithPaginationHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUsersWithPaginationQuery, Result<List<User>>>
    {
        public async Task<Result<List<User>>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.Users
                .GetFilteredUsersAsync(
                    request.SearchTerm,
                    request.Page,
                    request.PageSize,
                    cancellationToken
                );

            return Result.Success(result);
        }
    }
}
