import { Component, computed, input, signal } from '@angular/core';
import { fakeTasks } from './fake_tasks';
import { nawTask, TaskObj } from './tasks.moudle';
import { Task } from './task/task';
import { AddNewTask } from './add-new-task/add-new-task';

@Component({
  selector: 'app-tasks',
  imports: [Task,AddNewTask],
  templateUrl: './tasks.html',
  styleUrl: './tasks.css',
})
export class Tasks {

  username=input.required<string>();
  userid=input.required<number>();
  taskslist=signal<TaskObj []>( fakeTasks );
  usertasks=computed(()=>{
    return this.taskslist().filter((task:TaskObj)=>task.userId===this.userid());
  })
onClickCmpletedTask(taskId:string){
 
  this.taskslist.update(t=>t.filter( task=> task.id !== taskId))
   
}
isButtonClicked=signal(false);
onClickAddTask(){
this.isButtonClicked.set(true);
}
onClickCancal(){
  this.isButtonClicked.set(false);
}
onAddNewTask(newTaskObj:nawTask){
  const _newTask:TaskObj={
    id: 't'+(this.taskslist().length+1),
    userId: this.userid(),
    title: newTaskObj.title,
    summary: newTaskObj.summary,
    dueDate: newTaskObj.dueDate 
  }
  // דחיפת המשימה החדשה שיצרתי למערך המשימות
  this.taskslist.update((_taskList)=>_taskList.concat(_newTask))
this.isButtonClicked.set(false);
}
}