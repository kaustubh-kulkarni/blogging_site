import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegisterService } from '../../services/register.service';
import { Router } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, HttpClientModule],
  providers: [RegisterService, Router],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit{
  //Props
  registerForm!: FormGroup
  validationErrors: string[] = [];

  //CTOR
  constructor(private registerService: RegisterService, private router: Router){}

  ngOnInit(){
    this.initializeForm();
  }

  initializeForm(){
    this.registerForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  register(){
    console.info(this.registerForm.value);
    this.registerService.register(this.registerForm.value).subscribe(() => {
      this.router.navigateByUrl('');
    })
  }
}
