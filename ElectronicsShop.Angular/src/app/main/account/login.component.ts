import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { AuthService } from '../../shared/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form!: FormGroup;

  constructor(
    private titleService: Title,
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) {
    this.titleService.setTitle("Login");
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      username: new FormControl("", [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(15),
      ]),
      password: new FormControl("", [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(20),
      ])
    });
  }

  submit() {
    if (this.form.valid === false) {
      this.form.markAllAsTouched()
      return;
    }

    this.authService.login(this.form.getRawValue());
  }

}
