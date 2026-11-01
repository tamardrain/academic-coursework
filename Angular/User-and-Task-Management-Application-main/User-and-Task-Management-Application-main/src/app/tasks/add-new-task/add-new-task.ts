import { Component, output } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { nawTask } from '../tasks.moudle';

@Component({
  selector: 'app-add-new-task',
  imports: [FormsModule],
  templateUrl: './add-new-task.html',
  styleUrl: './add-new-task.css',
})
export class AddNewTask {
title='task title';
summary='this is a short summary';
dueDate=new Date().toISOString().split('T')[0];

addNewTask=output<nawTask>();
clodeDialog=output<void>();
  onSubmit(form: NgForm){
   if (form.invalid) {
    form.control.markAllAsTouched();
    return;
  }
  this.addNewTask.emit({
    title :this.title,
    summary : this.summary,
    dueDate : this.dueDate
  })

  }
  clodeDialogClicked(){
    this.clodeDialog.emit();
  }
}
