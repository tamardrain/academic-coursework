import { Component, inject, OnInit, signal } from '@angular/core';
import { UsersService } from '../../services/users.service';
import { User } from "../../components/user/user";
import { UserObj } from '../../modules/user.module';

@Component({
  selector: 'app-users',
  imports: [User],
  templateUrl: './users.html',
  styleUrl: './users.less',
})
export class Users implements OnInit {
  private userService = inject(UsersService);

  users: UserObj[] = []
  loading = signal<boolean>(true)
  error= signal<boolean>(false)
  ngOnInit() {
    this.userService.getAllUsers().subscribe({
      next: data => {
        this.users = data;
        this.loading.set(false);
      },
      error: err => {
        console.log('error:', err);
        this.loading.set(false);
        this.error.set(true);
      }
    });
  }

}
