import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  TaskSearchParams,
  TaskService,
  UserSearchParams,
} from './task.service';
import { AuthService } from '../auth/auth.service';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { TaskCreateDialogComponent } from './create-tasg-dialog/create-tasg-dialog';
type TaskStatus = 'Pending' | 'InProgress' | 'Completed';
export interface TaskItem {
  id: string;
  title: string;
  description: string;
  status: TaskStatus;
  assignedUserId?: string;
  dueDate?: Date;
  priority: string;
}
@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, TaskCreateDialogComponent],
  templateUrl: './tasks.html',
  styleUrl: './tasks.scss',
})
export class TasksComponent implements OnInit {
  private taskService = inject(TaskService);
  private authService = inject(AuthService);

  tasks: TaskItem[] = [];
  isAdmin = false;
  userId: string | null = null;
  searchParams: TaskSearchParams = {
    assignedUserId: '',
    status: '',
    page: 1,
    pageSize: 1000,
  };
  editingTask: TaskItem | null = null;

  users: any[] = [];
  showCreateDialog = false;
  groupedTasks: Record<TaskStatus, any[]> = {
    Pending: [],
    InProgress: [],
    Completed: [],
  };

  statusOptions: TaskStatus[] = ['Pending', 'InProgress', 'Completed'];

  ngOnInit(): void {
    this.isAdmin = this.authService.isAdmin();
    this.userId = this.authService.getUserId();

    if (this.isAdmin) {
      let filter: UserSearchParams = {
        searchTem: undefined,
        page: 1,
        pageSize: 1000,
      };
      this.taskService
        .getUsers(filter)
        .subscribe((users: any) => (this.users = users.value));
    }

    this.fetchTasks();
  }

  onSearch() {
    const params: TaskSearchParams = {
      ...this.searchParams,
      assignedUserId: this.isAdmin
        ? this.searchParams.assignedUserId
        : this.userId ?? undefined,
    };

    this.taskService.getTasks(params).subscribe({
      next: (res: any) => {
        this.tasks = res.value || res;
        this.groupTasksByStatus();
      },
      error: (err) => console.error(err),
    });
  }

  fetchTasks() {
    const params: TaskSearchParams = {
      ...this.searchParams,
      assignedUserId: this.isAdmin
        ? this.searchParams.assignedUserId
        : this.userId ?? undefined,
    };

    this.taskService.getTasks(params).subscribe({
      next: (res: any) => {
        this.tasks = res.value || res;
        this.groupTasksByStatus();
      },
      error: (err) => console.error(err),
    });
  }

  groupTasksByStatus() {
    this.groupedTasks = {
      Pending: [],
      InProgress: [],
      Completed: [],
    };
    this.tasks.forEach((task) => {
      if (this.groupedTasks[task.status as TaskStatus]) {
        this.groupedTasks[task.status as TaskStatus].push(task);
      }
    });
  }

  create() {
    this.editingTask = null;
    this.showCreateDialog = true;
  }

  edit(task: TaskItem) {
    this.editingTask = task;
    this.showCreateDialog = true;
  }

  onDialogClose(refresh = false) {
    this.showCreateDialog = false;
    if (refresh) {
      this.fetchTasks();
    }
  }

  clearSearch() {
    this.searchParams = {
      assignedUserId: '',
      status: '',
      page: 1,
      pageSize: 1000,
    };

    this.fetchTasks();
  }

  confirmDelete(task: TaskItem) {
    const confirmed = confirm(
      `Are you sure you want to delete "${task.title}"?`
    );
    if (confirmed) {
      this.taskService.deleteTask(task.id).subscribe({
        next: () => {
          this.fetchTasks(); // refresh the UI
        },
        error: (err) => console.error('Delete failed:', err),
      });
    }
  }
}
