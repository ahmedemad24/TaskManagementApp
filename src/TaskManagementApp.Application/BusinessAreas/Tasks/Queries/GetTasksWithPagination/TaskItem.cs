namespace TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTasksWithPagination
{
    public class TaskItemResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }

        public Guid? AssignedUserId { get; set; }
        public AssignedUserItem AssignedUser { get; set; }
    }

    public class AssignedUserItem
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
