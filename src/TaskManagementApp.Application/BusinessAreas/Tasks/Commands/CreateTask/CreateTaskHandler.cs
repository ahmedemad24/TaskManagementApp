using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Application.Interfaces.Persistence;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Commands.CreateTask
{
    public class CreateTaskHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateTaskCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                AssignedUserId = request.AssignedUserId,
                Priority = request.Priority,
                Status = request.Status
            };

            await unitOfWork.Tasks.AddAsync(task);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Guid>(task.Id);
        }
    }
}
