using MediatR;
using TaskManagementApp.Application.Common;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<Result<bool>>
    {
        public Guid TaskId { get; set; }
    }
}
