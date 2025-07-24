namespace TaskManagementApp.Application.Common
{
    public class BaseSearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
