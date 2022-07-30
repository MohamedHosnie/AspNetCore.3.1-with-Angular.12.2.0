import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomValidators } from '../../shared/helpers/custom-validators';
import { Exception } from '../../shared/service-proxies/service-proxies';
import { AuthService } from '../../shared/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  form!: FormGroup;
  duplicateUsername: boolean = false;

  constructor(
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      fullname: new FormControl("", [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(30)
      ]),
      username: new FormControl("", [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(15)
      ]),
      email: new FormControl("", [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(254),
        Validators.pattern(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/)
      ]),
      password: new FormControl("", [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(20)
      ]),
      fulladdress: new FormControl("", [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(50),
      ]),
      phonenumber: new FormControl("", [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(15),
        Validators.pattern(/^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$/)
      ]),
      birthdate: new FormControl("", [
        Validators.required,
        CustomValidators.AgeMoreThanThirteen,
        CustomValidators.Date
      ])
    });
  }

  submit() {
    console.log(this.form);
    if (this.form.valid === false) {
      return;
    }

    this.authService.register(this.form.getRawValue()).catch((error: Exception) => {
      if (error.response == (-1).toString()) {
        this.duplicateUsername = true;
      } else {
        this.duplicateUsername = false;
      }
    });
  }
}
