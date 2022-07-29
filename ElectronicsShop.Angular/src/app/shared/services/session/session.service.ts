import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Emitters } from '../../emitters/emitters';
import { AuthServiceProxy, Exception, GetLoggedInUserDto } from '../../service-proxies/service-proxies';
import { AuthService } from '../auth/auth.service';

@Injectable()
export class SessionService {

  private _user!: GetLoggedInUserDto | null;

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  get user(): GetLoggedInUserDto | null {
    return this._user;
  }

  set user(user: GetLoggedInUserDto | null) {
    this._user = user;
  }

  init(): Promise<GetLoggedInUserDto> {

    Emitters.authEmitter.subscribe(auth => {
      if (auth == false) {
        this.user = null;
        Emitters.userDataEmitter.emit(this.user);
        this.router.navigate(['/']);
      } else if (auth == true) {
        this.authService.getLoggedInUser().then((user: GetLoggedInUserDto) => {
          this._user = user;
          Emitters.userDataEmitter.emit(user);
          this.router.navigate(['/']);
        }).catch((error) => {
          this._user = null;
          Emitters.userDataEmitter.emit(null);
          this.router.navigate(['/']);
        });
      }
    });

    return new Promise<GetLoggedInUserDto>((resolve, reject) => {
      this.authService.getLoggedInUser().then((user: GetLoggedInUserDto) => {
        this._user = user;
        resolve(user);
      }).catch((error) => {
        reject(error);
      });
    });
  }

}
