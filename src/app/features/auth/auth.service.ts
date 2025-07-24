import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { environment } from '../../../environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly tokenKey = 'auth_token';
  private readonly baseUrl = `${environment.apiUrl}/Auth`;

  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<string> {
    return this.http
      .post<{ value: string }>(this.baseUrl, { email, password })
      .pipe(
        tap((res) => localStorage.setItem(this.tokenKey, res.value)),
        map((res) => res.value)
      );
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isAdmin(): boolean {
    const token = this.getToken();
    if (!token) return false;

    const payload = JSON.parse(atob(token.split('.')[1]));
    console.log(payload);

    return payload.IsAdmin === 'True';
  }

  getUserId(): string | null {
    const token = this.getToken();
    if (!token) return null;

    const payload = JSON.parse(atob(token.split('.')[1]));
    return payload.sub;
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }
}
