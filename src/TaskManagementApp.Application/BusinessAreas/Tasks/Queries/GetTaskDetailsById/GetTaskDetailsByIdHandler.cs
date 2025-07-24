using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Application.Interfaces.Persistence;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTaskDetailsById
{
    public class GetTaskDetailsByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTaskDetailsByIdQuery, Result<TaskItem>>
    {
        public async Task<Result<TaskItem>> Handle(GetTaskDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await unitOfWork.Tasks.GetByIdAsync(request.TaskId);
            if (task == null)
            {
                return Result.Failure<TaskItem>("Task not found.");
            }

            return Result.Success(task);
        }
    }
}
