namespace TaskManagementApp.Api.Controllers.Auth.DTOs
{
    /// <summary>
    /// Represents a request to log in to the application.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }
    }

}
