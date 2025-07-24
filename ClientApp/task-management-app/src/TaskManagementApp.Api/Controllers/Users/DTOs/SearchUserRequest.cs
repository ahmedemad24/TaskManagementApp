using TaskManagementApp.Application.Common;

namespace TaskManagementApp.Api.Controllers.Users.DTOs
{
    /// <summary>
    /// Represents the search and pagination request for users.
    /// </summary>
    public class SearchUserRequest : BaseSearchRequest
    {
        /// <summary>
        /// search term to search by full name or email.
        /// </summary>
        public string? SearchTerm { get; set; }
    }
}
