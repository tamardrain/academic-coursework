import { Component, input, output, signal } from '@angular/core';
import { users } from './users';
import { userObj } from './user.moudle';



@Component({
  selector: 'app-user',
  imports: [],
  templateUrl: './user.html',
  styleUrl: './user.css',
})
export class User {
  
// ---------------------------------
//אם רוצים שיהיה כפתור אחד ועליו יופיעו בכל פעם פרטים אחרים מוגרלים מתוך המערך
// currentUser= signal(this._users[0])

// onclicked(){
//   const randomIndex = Math.floor(Math.random() * this._users.length);
//   this.currentUser.set(this._users[randomIndex])
// }
// בקובץ הTS יופיע על הכפתור האירוע הזה...
// (click)= "onclicked()"
// --------------------------------
_users = users
// //ישמור את שם המשתמש
// username= input<string>(" ");
// //ישמור את הנתיב לקובץ עם התמונה של המשתמש
// avater= input<string>();
// // הגדרת מזהה ושליחתו לאבא
selectedname=output<number>();//יצירת משתנה שיצור אירוע עם האבא
user=input.required<userObj>();
 
  selectUser() {
    // כשמשתמש לוחץ על קומפוננטת User
    this.selectedname.emit(this.user().id); // שולח את ה-id לאבא
  }
 
 
isSelected = input<boolean>();
}
