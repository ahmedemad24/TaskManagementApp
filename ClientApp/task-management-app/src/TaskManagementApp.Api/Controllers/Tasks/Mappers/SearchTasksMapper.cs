using TaskManagementApp.Api.Controllers.Tasks.DTOs;
using TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTasksWithPagination;
using TaskManagementApp.Application.Common;

namespace TaskManagementApp.Api.Controllers.Tasks.Mappers
{
    public static class SearchTasksMapper
    {
        /// <summary>
        /// Maps a <see cref="SearchTasksRequest"/> to a <see cref="GetTasksWithPaginationQuery"/>.
        /// </summary>
        public static GetTasksWithPaginationQuery ToQuery(this SearchTasksRequest request)
        {
            return new GetTasksWithPaginationQuery
            {
                AssignedUserId = request.AssignedUserId,
                Status = request.Status,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }

        public static Result<List<TaskItemResultDto>> ToResultDto(Result<List<TaskItemResult>> result)
        {
            if (result.IsFailure)
                return Result.Failure<List<TaskItemResultDto>>(result.Error!);

            var mapped = result!.Value!.Select(t => new TaskItemResultDto
            {
                Id = t.Id,
                Title = t.Title,
                Status = t.Status.ToString(),
                Priority = t.Priority.ToString(),
                DueDate = t.DueDate,
                AssignedUserId = t.AssignedUserId,
                AssignedUser = new AssignedUserItemDto
                {
                    FullName = t!.AssignedUser!.FullName ?? "",
                    Email = t.AssignedUser.Email
                }
            }).ToList();

            return Result.Success(mapped);
        }
    }
}
