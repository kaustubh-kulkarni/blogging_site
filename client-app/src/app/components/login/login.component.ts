import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  onSubmit(){
    console.info(this.loginForm.value);
  }

}
