import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable, tap } from 'rxjs';

export interface TaskSearchParams {
  assignedUserId?: string;
  status?: string;
  page?: number;
  pageSize?: number;
}

export interface UserSearchParams {
  searchTem?: string;
  page?: number;
  pageSize?: number;
}

export interface CreateTaskDto {
  title: string;
  description: string;
  dueDate: Date;
  status: string;
  priority: string;
  assignedUserId: string;
}

@Injectable({ providedIn: 'root' })
export class TaskService {
  private baseUrl = 'https://localhost:7061/api/Task';
  private baseUserSearchUrl = 'https://localhost:7061/api/Users';

  constructor(private http: HttpClient) {}

  getTasks(params: TaskSearchParams): Observable<any[]> {
    let httpParams = new HttpParams();

    if (params.assignedUserId) {
      httpParams = httpParams.set('assignedUserId', params.assignedUserId);
    }
    if (params.status) {
      httpParams = httpParams.set('status', params.status);
    }
    if (params.page) {
      httpParams = httpParams.set('page', params.page);
    }
    if (params.pageSize) {
      httpParams = httpParams.set('pageSize', params.pageSize);
    }

    return this.http.get<any[]>(`${this.baseUrl}/search`, {
      params: httpParams,
    });
  }

  getTasksByUserId(userId: string): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.baseUrl}/search?assignedUserId=${userId}`
    );
  }

  createTask(dto: CreateTaskDto): Observable<any> {
    return this.http
      .post<{ value: string }>(this.baseUrl, dto)
      .pipe(map((res) => res.value));
  }

  updateTask(id: string, dto: CreateTaskDto): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, dto);
  }

  getUsers(params: UserSearchParams): Observable<any[]> {
    let httpParams = new HttpParams();

    if (params.searchTem) {
      httpParams = httpParams.set('searchTem', params.searchTem);
    }
    if (params.page) {
      httpParams = httpParams.set('page', params.page);
    }
    if (params.pageSize) {
      httpParams = httpParams.set('pageSize', params.pageSize);
    }

    return this.http.get<any[]>(`${this.baseUserSearchUrl}/search`, {
      params: httpParams,
    });
  }

  deleteTask(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
