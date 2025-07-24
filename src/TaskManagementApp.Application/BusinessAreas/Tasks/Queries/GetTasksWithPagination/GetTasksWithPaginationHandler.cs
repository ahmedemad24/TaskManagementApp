using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Application.Interfaces.Persistence;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTasksWithPagination
{
    public class GetTasksWithPaginationHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTasksWithPaginationQuery, Result<List<TaskItemResult>>>
    {
        public async Task<Result<List<TaskItemResult>>> Handle(GetTasksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.Tasks
                .GetFilteredTasksAsync(
                    request.AssignedUserId,
                    request.Status,
                    request.Page,
                    request.PageSize,
                    cancellationToken
                );

            return Result.Success(result);
        }
    }
}
