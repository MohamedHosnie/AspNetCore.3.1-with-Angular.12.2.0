import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Emitters } from '../../emitters/emitters';
import { AuthServiceProxy, CreateUserDto, Exception, LoginDto, UserDto } from '../../service-proxies/service-proxies';
import { SessionService } from '../session/session.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private _isAuthenticated = false;
  private token!: string;

  constructor(
    private authServiceProxy: AuthServiceProxy,
    private toastr: ToastrService
  ) { }

  get isAuthenticated() {
    return this._isAuthenticated && this.token != null;
  }

  getToken(): string {
    if (this.token == null) {
      this.token = localStorage.getItem("jwt-auth-token") as string;
    }
    return this.token;
  }

  setToken(token: string): void {
    this.token = token;
    localStorage.setItem("jwt-auth-token", token);
  }

  removeToken(): void {
    this.token = "";
    localStorage.removeItem("jwt-auth-token");
  }

  getLoggedInUser(): Promise<UserDto> {
    return new Promise<UserDto>((resolve, reject) => {
      this.authServiceProxy.getLoggedInUser().subscribe((user: UserDto) => {
        if (user.id != null) {
          this._isAuthenticated = true;
          resolve(user);
        } else {
          this.removeToken();
          this._isAuthenticated = false;
          reject(user);
        }
      }, (error: Exception) => {
        if (error.status == 401) {
          //user is not authorized
        }
        this.removeToken();
        this._isAuthenticated = false;
        reject(error);
      });
    });
  }

  login(user: LoginDto): Promise<string> {
    return new Promise<string>((resolve, reject) => {
      this.authServiceProxy.login(user).subscribe((token: string) => {
        if (token.length > 0) {
          this.setToken(token);
          this._isAuthenticated = true;
          resolve(token);
          this.toastr.success("Logged in successfully!!", "Success!!");
          Emitters.authEmitter.emit(true);
        } else {
          this.removeToken();
          this._isAuthenticated = false;
          reject(token);
          Emitters.authEmitter.emit(false);
        }
      }, (error: Exception) => {
        this.toastr.error(error.response, "Something is wrong");
        this.removeToken();
        this._isAuthenticated = false;
        reject(error);
        Emitters.authEmitter.emit(false);
      });
    });
  }

  logout(): void {
    this.removeToken();
    Emitters.unauthEmitter.emit(false);
  }

  register(user: CreateUserDto) {
    return new Promise<number>((resolve, reject) => {
      this.authServiceProxy.register(user).subscribe((userId: number) => {
        if (userId >= 0) {
          this.login(new LoginDto({
            username: user.username,
            password: user.password
          }));
        } else {
          if (userId == -1) {
            //username is not available
            this.toastr.error("Username already exists", "Something is wrong");
          }
          reject(userId);
        }
      }, (error: Exception) => {
        this.toastr.error(error.response, "Something is wrong");
        reject(error);
      });
    });
  }

}
