import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth/auth.service';

@Injectable()
export class ProxyInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService
  ) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    var requestHeaders = new HttpHeaders();

    requestHeaders = this.addAuthorizationHeader(request.headers);

    request = request.clone({
      headers: requestHeaders
    });

    return next.handle(request);
  }

  private addAuthorizationHeader(headers: HttpHeaders): HttpHeaders {
    var token = this.authService.getToken();

    if (headers && token) {
      headers = headers.set('Authorization', 'Bearer ' + token);
    }

    return headers;
  }
}
