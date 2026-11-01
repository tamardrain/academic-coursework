import { computed, inject, Injectable, signal } from "@angular/core";
import { ArticleObj } from "../modules/article.module";
import { HttpClient } from "@angular/common/http";


@Injectable({ providedIn: 'root' })

export class ArticlesService {
   private http=inject(HttpClient)
    articlesstate = signal<ArticleObj[]>([]);
    //טעינת כל המאמרים מהשרת
    loadArticles() {
    this.http
      .get<ArticleObj[]>('https://jsonplaceholder.typicode.com/posts')
      .subscribe(data => {
        this.articlesstate.set(data);
      });
  }
    //לקריאה בלבד מבחוץ
    articles = this.articlesstate.asReadonly();

    //שליפת מאמרים לפי משתמש
 getArticlesByUserId(userId: number) {
  return computed(() =>
    this.articlesstate().filter(a => a.userId === userId)
  );
}

    //שליפת מאמר לפי קוד
    getArticleById(articleId: number) {
        return computed(() => this.articlesstate().find(a => a.id === articleId));
    }
    updateStatus(articleId: number) {
        this.articlesstate.update(
            (a) => a.map(
                (art) => art.id === articleId ? { ...art, isPublished: !art.isPublished } 
                : art))
    }
allCompletedByUser = (userId: number) =>
  computed(() => {
    const articles = this.articlesstate().filter(
      a => a.userId === userId
    );

    if (articles.length === 0) return false;

    return articles.every(a => a.isPublished);
  });


}