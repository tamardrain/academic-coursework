import { computed, inject, Injectable, signal } from "@angular/core";
import { ArticleObj } from "../modules/article.module";
import { ArticlesService } from "./articles.service";

@Injectable({ providedIn: 'root' })

export class ProgressService {
   articlesService = inject(ArticlesService);
getUserStatus = (userId: number) =>
  computed(() => {

    const articles = this.articlesService
      .articlesstate()
      .filter(a => a.userId === userId);

    if (articles.length === 0)
      return false;

    return articles.every(a => a.isPublished);
  });


}