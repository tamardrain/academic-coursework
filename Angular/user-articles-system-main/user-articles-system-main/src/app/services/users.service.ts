import { inject, Injectable, signal } from "@angular/core";
import { UserObj } from "../modules/user.module";

import { HttpClient } from "@angular/common/http";

@Injectable({ providedIn:'root'})

export class UsersService{
    http=inject(HttpClient);
    selectedUser=signal<UserObj | null>(null);
    //שליפת כל המשתמשים
getAllUsers(){
return this.http.get<UserObj[]>('https://jsonplaceholder.typicode.com/users')
}
//שליפת המשתמש הנבחר
getSelectedUser(){
    return this.selectedUser();
}
//שליפת משתמש לפי מזהה
getUserById(id:number){
   return this.http.get<UserObj>(`https://jsonplaceholder.typicode.com/users/${id}`)
}
//עדכון משתמש שנבחר
setSelectedUser(user: UserObj | null){
    this.selectedUser.set(user);
}
}