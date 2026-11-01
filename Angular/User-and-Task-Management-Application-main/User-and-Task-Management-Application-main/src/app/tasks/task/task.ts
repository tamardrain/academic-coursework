import { Component, input, output } from '@angular/core';
import { TaskObj } from '../tasks.moudle';



@Component({
  selector: 'app-task',
  imports: [],
  templateUrl: './task.html',
  styleUrl: './task.css',
})
export class Task {
task=input.required<TaskObj>();
taskCompleted=output<string>();
onClickCmpletedTask(){
   
  this.taskCompleted.emit(this.task().id)
}
}
