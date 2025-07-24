using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTaskDetailsById
{
    public class GetTaskDetailsByIdQuery : IRequest<Result<TaskItem>>
    {
        public Guid TaskId { get; set; }
    }
}
