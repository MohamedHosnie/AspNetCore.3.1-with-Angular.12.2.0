import { Injectable } from '@angular/core';
import { Emitters } from '../../emitters/emitters';
import { AuthServiceProxy, Exception, GetLoggedInUserDto, LoginDto, UserDto } from '../../service-proxies/service-proxies';
import { SessionService } from '../session/session.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private _isAuthenticated = false;
  private token!: string;

  constructor(
    private authServiceProxy: AuthServiceProxy
  ) { }

  get isAuthenticated() {
    return this._isAuthenticated && this.token != null;
  }

  public getToken(): string {
    if (this.token == null) {
      this.token = localStorage.getItem("jwt-auth-token") as string;
    }
    return this.token;
  }

  public setToken(token: string): void {
    this.token = token;
    localStorage.setItem("jwt-auth-token", token);
  }

  public removeToken(): void {
    this.token = "";
    localStorage.removeItem("jwt-auth-token");
  }

  public getLoggedInUser(): Promise<GetLoggedInUserDto> {
    return new Promise<GetLoggedInUserDto>((resolve, reject) => {
      this.authServiceProxy.getLoggedInUser().subscribe((user: GetLoggedInUserDto) => {
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

  public login(user: LoginDto): Promise<string> {
    return new Promise<string>((resolve, reject) => {
      this.authServiceProxy.login(user).subscribe((token: string) => {
        if (token.length > 0) {
          this.setToken(token);
          this._isAuthenticated = true;
          resolve(token);
          Emitters.authEmitter.emit(true);
        } else {
          this.removeToken();
          this._isAuthenticated = false;
          reject(token);
          Emitters.authEmitter.emit(false);
        }
      }, (error) => {
        this.removeToken();
        this._isAuthenticated = false;
        reject(error);
        Emitters.authEmitter.emit(false);
      });
    });
  }

  public logout(): void {
    this.removeToken();
    Emitters.authEmitter.emit(false);
  }

  register(user: UserDto) {
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
            console.error("Username already exists");
          }
          reject(userId);
        }
      }, (error) => {
        reject(error);
      });
    });
  }

}
