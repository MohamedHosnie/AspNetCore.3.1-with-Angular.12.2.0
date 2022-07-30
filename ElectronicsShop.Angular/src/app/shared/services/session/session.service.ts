import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Emitters } from '../../emitters/emitters';
import { AuthServiceProxy, Exception, UserDto } from '../../service-proxies/service-proxies';
import { AuthService } from '../auth/auth.service';

@Injectable()
export class SessionService {

  private _user!: UserDto | null;

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  get user(): UserDto | null {
    return this._user;
  }

  set user(user: UserDto | null) {
    this._user = user;
  }

  init(): Promise<UserDto> {

    Emitters.authEmitter.subscribe(auth => {
      if (auth == false) {
        this.user = null;
        Emitters.userDataEmitter.emit(this.user);
      } else if (auth == true) {
        this.authService.getLoggedInUser().then((user: UserDto) => {
          this._user = user;
          Emitters.userDataEmitter.emit(user);
          this.router.navigate(['/']);
        }).catch((error) => {
          this.toastr.error(error.response, "Something is wrong");
          this._user = null;
          Emitters.userDataEmitter.emit(null);
          this.router.navigate(['/']);
        });
      }
    });

    Emitters.unauthEmitter.subscribe(() => {
      this.user = null;
      Emitters.userDataEmitter.emit(this.user);
      this.router.navigate(['/']);
    });

    return new Promise<UserDto>((resolve, reject) => {
      this.authService.getLoggedInUser().then((user: UserDto) => {
        this._user = user;
        resolve(user);
      }).catch((error) => {
        reject(error);
      });
    });
  }

}
