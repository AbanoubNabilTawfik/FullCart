import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ResponseDto } from 'src/@full-cart/Models/Common/response';
import { login } from 'src/@full-cart/Models/auth/login';
import { AlertService } from 'src/@full-cart/Services/alert.service';
import {AuthService} from 'src/@full-cart/Services/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm?: any;

  constructor(private router:Router,private fb: FormBuilder,private AuthService: AuthService,private alertService: AlertService) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  get email() {
    return this.loginForm?.get('email');
  }

  get password() {
    return this.loginForm?.get('password');
  }
 
  onSubmit() {
    if (this.loginForm?.valid) {
      // Implement your login logic here
      let body: login = {
        email: this.loginForm.get('email')?.value.trim(),
        password: this.loginForm.get('password')?.value.trim(),
      };
      this.AuthService.Login(body).subscribe(
        (response: ResponseDto) => {
          if (response.isPassed == true) {
            console.log("res",response)
            this.alertService.showSuccess(response.message);
            const Role = [response.data.role];
            const email=[response.data.email];
            this.AuthService.isLoggedInVar=true;
            localStorage.setItem('Role', JSON.stringify(Role));
            localStorage.setItem('email', JSON.stringify(email));
            localStorage.setItem(
              'ecommerce_user',
              JSON.stringify(response.data)
            );
            if(response.data.role=="Admin")
            {
              
              this.router.navigate(['/item-list'])
            }
            else
            {
              //navigate to loged in
            }
            }
            else
            {
              this.alertService.showSuccess(response.message);
            } 
        },
        (error: Error) => {
          console.log(error);
          this.alertService.showError(error.message);
        }
      );

    }
  }
}
