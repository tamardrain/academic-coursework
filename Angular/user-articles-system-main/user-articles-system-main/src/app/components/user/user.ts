import { Component, inject, input } from '@angular/core';
import { UsersService } from '../../services/users.service';
import { UserObj } from '../../modules/user.module';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  imports: [],
  templateUrl: './user.html',
  styleUrl: './user.less',
})
export class User {
userService=inject(UsersService);
router=inject(Router)
currentUser = input.required<UserObj | null>();

openProfileClicked() {
  const user = this.currentUser();
  if (!user) return;

  this.userService.setSelectedUser(user);
  this.router.navigate(['/users', user.id]);
}
}
