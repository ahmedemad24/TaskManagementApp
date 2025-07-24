using MediatR;
using TaskManagementApp.Application.Common;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTasksWithPagination
{
    public class GetTasksWithPaginationQuery : IRequest<Result<List<TaskItemResult>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Guid? AssignedUserId { get; set; }
        public Domain.Enums.TaskStatus? Status { get; set; }
    }
}
