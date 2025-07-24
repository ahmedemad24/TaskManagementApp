using TaskManagementApp.Api.Controllers.Users.DTOs;
using TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTasksWithPagination;
using TaskManagementApp.Application.BusinessAreas.Users.Queries.GetUsersWithPagination;

namespace TaskManagementApp.Api.Controllers.Users.Mappers
{
    public static class SearchUsersMapper
    {
        /// <summary>
        /// Maps a <see cref="SearchUserRequest"/> to a <see cref="GetTasksWithPaginationQuery"/>.
        /// </summary>
        public static GetUsersWithPaginationQuery ToQuery(this SearchUserRequest request)
        {
            return new GetUsersWithPaginationQuery
            {
                SearchTerm = request.SearchTerm,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
