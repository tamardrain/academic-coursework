import { Component, output } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { userObj } from '../user/user.moudle';


@Component({
  selector: 'app-add-new-user',
  imports: [ReactiveFormsModule],
  templateUrl: './add-new-user.html',
  styleUrl: './add-new-user.css',
})
export class AddNewUser {
  categories = ['urgent', 'personal', 'work'];
  passwordMatch(group: AbstractControl) {
    const p = group.get('pass')?.value;
    const c = group.get('confirmPass')?.value;
    return p === c ? null : { mismatch: true }
  }
  get first() {
    return this.addFormUser.get('name.first');
  }
  get last() {
    return this.addFormUser.get('name.last');
  }
  get email() {
    return this.addFormUser.get('email');
  }
  addFormUser = new FormGroup({
    name: new FormGroup({
      first: new FormControl('', [Validators.required, Validators.maxLength(18)]),
      last: new FormControl('', [Validators.required, Validators.maxLength(18)])
    }),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormGroup({
      pass: new FormControl('', [Validators.required, Validators.minLength(6)]),
      confirmPass: new FormControl('', [Validators.required]),
    }, { validators: this.passwordMatch }),
    categories: new FormArray(
      this.categories.map(() => new FormControl(false))
    )
  });

  addNewUser = output<{ name: string }>();
  onSubmit() {
    if (this.addFormUser.invalid) {
    this.addFormUser.markAllAsTouched();
    return;
  }
    const nameGroup = this.addFormUser.get('name') as FormGroup;

    this.addNewUser.emit({
      name: `${nameGroup.get('first')?.value} ${nameGroup.get('last')?.value}`
    });
    
  }
  closeDialog=output<void>();
  closeDialogClicked(){
    console.log('EMIT CLOSE');
    this.closeDialog.emit();
  }
} 
