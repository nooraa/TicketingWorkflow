import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { LoginService } from '../../Services/login-Service';
@Component({
  selector: 'app-login',
  templateUrl: './login-component.html',
  styleUrls: ['./login-component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup = new FormGroup({
    password: new FormControl(''),
    username: new FormControl(''),
  }); 
  public loginInvalid = false;
  private formSubmitAttempt = false;
  constructor(private loginService: LoginService) { }

  ngOnInit(): void {

  }
  onSubmit(): void {
    this.loginInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const username = this.form.controls['username']?.value;
        const password = this.form.controls['password']?.value;
        this.loginService.login(username, password).subscribe(l =>this.loginInvalid = l);
      } catch (err) {
        this.loginInvalid = true;
      }
    } else {
      this.formSubmitAttempt = true;
    }
  }
}
