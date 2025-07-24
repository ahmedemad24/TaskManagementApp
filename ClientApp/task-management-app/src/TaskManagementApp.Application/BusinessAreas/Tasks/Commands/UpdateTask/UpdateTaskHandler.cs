using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Application.Interfaces.Persistence;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Commands.UpdateTask
{
    public class UpdateTaskHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateTaskCommand, Result<bool>>
    {
        private UpdateTaskCommand _request = null!;
        private IUnitOfWork _unitOfWork = null!;
        public async Task<Result<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            _request = request;
            _unitOfWork = unitOfWork;

            var task = await unitOfWork.Tasks.GetByIdAsync(request.TaskId);

            if (task is null)
            {
                return Result.Failure<bool>("Task not found.");
            }

            await MapUpdate(task);
            return Result.Success(true);
        }

        private async Task MapUpdate(TaskItem task)
        {
            task.Title = _request.Title;
            task.Description = _request.Description;
            task.DueDate = _request.DueDate;
            task.AssignedUserId = _request.AssignedUserId;
            task.Status = _request.Status;
            task.Priority = _request.Priority;

            _unitOfWork.Tasks.UpdateAsync(task);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
