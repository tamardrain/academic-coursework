import { Component, computed, inject, OnInit } from '@angular/core';
import { ArticlesService } from '../../services/articles.service';
import { Article } from "../../components/articles/article";
import { Router } from '@angular/router';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'app-articles',
  imports: [Article],
  templateUrl: './articles.html',
  styleUrl: './articles.less',
})
export class Articles implements OnInit {

  articlesService = inject(ArticlesService);
  userService = inject(UsersService);
  router = inject(Router);

  ngOnInit(){
  this.articlesService.loadArticles()
  }
  userId = computed(() => this.userService.selectedUser()?.id);

  articles = computed(() => {
    const id = this.userId();
    if (!id) return [];

    return this.articlesService.getArticlesByUserId(id)();
  });

  readAllArticles = computed(() => {
    const id = this.userId();

    if (!id) return false;

    return this.articlesService.allCompletedByUser(id)();
  });

  goBackToUser() {
    const id = this.userId();
    if (!id) return;

    this.router.navigate(['/users', id]);
  }
}