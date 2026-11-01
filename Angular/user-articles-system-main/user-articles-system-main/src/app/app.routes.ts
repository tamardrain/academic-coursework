import { Routes } from '@angular/router';
import { Users } from './pages/users/users';
import { UserProfile } from './pages/user-profile/user-profile';
import { Articles } from './pages/articles/articles';

export const routes: Routes = [
    {path: 'users',component:Users},
    {path: 'users/:id',component:UserProfile},
    {path: 'users/:id/articles',component:Articles},
    {path: '', redirectTo: 'users', pathMatch: 'full'},

];
