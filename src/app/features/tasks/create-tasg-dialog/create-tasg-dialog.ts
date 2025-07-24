import { CommonModule } from '@angular/common';
import { Component, Output, EventEmitter, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CreateTaskDto, TaskService } from '../task.service';
import { TaskItem } from '../tasks';

// task-create-dialog.component.ts
@Component({
  selector: 'app-task-create-dialog',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create-tasg-dialog.html',
  styleUrl: './create-tasg-dialog.scss',
})
export class TaskCreateDialogComponent {
  @Input() task?: TaskItem;
  @Input() users: any[] = [];
  @Output() close = new EventEmitter<boolean>();
  title = '';
  status = 'Pending';
  description = '';
  priority = '';
  assignedUserId = '';
  dueDate: Date = new Date();
  priorityOptions: any[] = [
    { name: 'Low' },
    { name: 'Medium' },
    { name: 'High' },
  ];

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    if (this.task) {
      this.title = this.task.title;
      this.description = this.task.description ?? '';
      this.status = this.task.status;
      this.priority = this.task.priority;
      this.assignedUserId = this.task.assignedUserId ?? '';
      this.dueDate = new Date(this.task.dueDate ?? '');
    }
  }

  submit() {
    const dto: CreateTaskDto = {
      title: this.title,
      description: this.description,
      dueDate: this.dueDate,
      status: this.status,
      priority: this.priority,
      assignedUserId: this.assignedUserId,
    };

    if (this.task) {
      // Update task
      this.taskService.updateTask(this.task.id, dto).subscribe(() => {
        this.close.emit(true);
      });
    } else {
      // Create task
      this.taskService.createTask(dto).subscribe(() => {
        this.close.emit(true);
      });
    }
  }

  cancel() {
    this.close.emit(false);
  }
}
