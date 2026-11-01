import { Component, computed, inject } from '@angular/core';
import { UsersService } from '../../services/users.service';
import { ProgressService } from '../../services/progress.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { effect } from '@angular/core';

@Component({
  selector: 'app-user-profile',
  imports: [],
  templateUrl: './user-profile.html',
  styleUrl: './user-profile.less',
})
export class UserProfile {

  userService = inject(UsersService);
  userProgress = inject(ProgressService);
  router = inject(Router);
route = inject(ActivatedRoute);
  selectedUser = this.userService.selectedUser;
ngOnInit() {
  const id = Number(this.route.snapshot.paramMap.get('id'));

  this.userService.getUserById(id).subscribe(user => {
    this.userService.setSelectedUser(user);
  });
}

isEligible = computed(() => {

  const user = this.selectedUser();

  if (!user)
    return false;

  return this.userProgress
    .getUserStatus(user.id)();
});

  goToUserArticles() {
  const id = Number(this.route.snapshot.paramMap.get('id'));
  if (!id) return;

  this.router.navigate(['/users', id, 'articles']);
}

  goBackToUsers() {
    this.router.navigate(['/users']);
  }
}