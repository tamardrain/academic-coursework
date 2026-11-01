import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MyHeader } from './my-header/my-header';
import { User } from './user/user';
import { users } from './user/users';
import { Tasks } from './tasks/tasks';
import { userObj } from './user/user.moudle';
import { AddNewUser } from './add-new-user/add-new-user';

@Component({
  selector: 'app-root',
  imports: [MyHeader,User,Tasks,AddNewUser],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
//יבוא הדאטא מהקומפוננטה שלה
  userslist=users
  // Signal ששומר את המזהה של המשתמש הנבחר
  selectedUsername = signal<userObj |null>(null);

  // הפונקציה שמופעלת כשהילד שולח אירוע
  onselectedid(userId: number) {
    console.log('selected userId:' ,userId);
    const user=this.userslist.find(u=>u.id==userId)||null;
    this.selectedUsername.set(user);
  }
  isaddUserClick=signal<boolean>(false)
  addUserClicked(){
     console.log('OPEN CLICKED');
   this.isaddUserClick.set(true)
  }
  onAddNewUser(newUser:{name: string}){
    const id=Date.now();
    const user: userObj={
      id,
      name:newUser.name,
      avater:"user-1.jpg"
    }
this.userslist.push(user);
this.isaddUserClick.set(false);
  }
  onCloseDialog(){
    console.log('CLOSE FIRED');
    this.isaddUserClick.set(false);
  }
  
}
