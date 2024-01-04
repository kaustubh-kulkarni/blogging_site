import { Component, OnInit, importProvidersFrom } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginService } from '../../services/login.service';
import { HttpClientModule } from '@angular/common/http';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, HttpClientModule],
  providers: [LoginService],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  constructor(private loginService: LoginService){}

  ngOnInit(): void{
    this.initializeForm();
  }

  initializeForm(){
    this.loginForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  login(){
    console.info(this.loginForm.value);
    //Call in the login service
    this.loginService.login(this.loginForm.value).subscribe(res => {
      console.info(res);
    })
  }

}
