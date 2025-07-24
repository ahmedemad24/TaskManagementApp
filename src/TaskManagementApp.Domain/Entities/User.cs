﻿namespace TaskManagementApp.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }

        // Navigation property
        public IReadOnlyCollection<TaskItem> Tasks { get; set; } = new HashSet<TaskItem>();
    }
}
