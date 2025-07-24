using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Application.Interfaces.Persistence;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Commands.DeleteTask
{
    public class DeleteTaskHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteTaskCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await unitOfWork.Tasks.GetByIdAsync(request.TaskId);

            if (task is null)
            {
                return Result.Failure<bool>("Task not found.");
            }

            if (task.Status != Domain.Enums.TaskStatus.Pending)
            {
                return Result.Failure<bool>("Pending tasks only can be deleted!");
            }

            unitOfWork.Tasks.Remove(task);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(true);
        }
    }
}
