namespace TaskManagementApp.Api.Controllers.Users.DTOs
{
    /// <summary>
    /// Represents the request payload for creating a new user.
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        public string FullName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Gets or sets the password of the user. 
        /// Should meet the application's strong password policy.
        /// </summary>
        public string Password { get; set; } = default!;
    }
}
