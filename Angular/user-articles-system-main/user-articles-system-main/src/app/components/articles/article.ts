import { Component, inject, input } from '@angular/core';
import { ArticleObj } from '../../modules/article.module';
import { ArticlesService } from '../../services/articles.service';

@Component({
  selector: 'app-article',
  imports: [],
  templateUrl: './article.html',
  styleUrl: './article.less',
})
export class Article {
  articlesService = inject(ArticlesService);
 
article = input.required<ArticleObj>();
}
