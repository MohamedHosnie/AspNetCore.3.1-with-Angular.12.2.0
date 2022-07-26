import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Role } from '../../app-enums';
import { SessionService } from '../session/session.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(
    private sessionService: SessionService,
    private router: Router
  ) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree
  {
    return new Promise<boolean | UrlTree>((resolve, reject) => {
      if (this.sessionService.user != null) {
        resolve(this.sessionService.user.role == Role.Admin || this.router.createUrlTree(['/error']));
      } else {
        resolve(this.router.createUrlTree(['/error']));
      }
    });
  }
  
}
