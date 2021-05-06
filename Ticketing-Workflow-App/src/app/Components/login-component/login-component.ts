import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { LoginService } from '../../Services/login-Service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login-component.html',
  styleUrls: ['./login-component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup = new FormGroup({
    password: new FormControl('', [Validators.required]),
    username: new FormControl('', [Validators.required]),
  }); 
  public loginInvalid = false;
  private formSubmitAttempt = false;
  constructor(private loginService: LoginService, private route: Router) { }

  ngOnInit(): void {

  }
  onSubmit(): void {
    this.loginInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const username = this.form.controls['username']?.value;
        const password = this.form.controls['password']?.value;
        let name = '';
        this.loginService.login(username, password).subscribe(user => name = user?.username);
          this.route.navigate(['/dashboard']);

      } catch (err) {
        this.loginInvalid = true;
      }
    } else {
      this.formSubmitAttempt = true;
    }
  }
}
