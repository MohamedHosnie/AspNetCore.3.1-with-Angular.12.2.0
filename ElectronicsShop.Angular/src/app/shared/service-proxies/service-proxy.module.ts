import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ProxyInterceptor } from './proxy.interceptor';
import { AuthServiceProxy } from './service-proxies';



@NgModule({
  providers: [
    AuthServiceProxy,
    { provide: HTTP_INTERCEPTORS, useClass: ProxyInterceptor, multi: true }
  ]
})
export class ServiceProxyModule { }
