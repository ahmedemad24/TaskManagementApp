import { Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login';
import { AuthGuard } from './features/auth/auth.guard';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  {
    path: 'tasks',
    canActivate: [AuthGuard],
    loadChildren: () =>
      import('../app/features/tasks/tasks.routes').then((m) => m.routes),
  },
];
