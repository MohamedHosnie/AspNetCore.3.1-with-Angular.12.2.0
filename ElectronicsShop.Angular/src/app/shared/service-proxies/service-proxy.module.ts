import { NgModule } from '@angular/core';
import { AuthServiceProxy } from './service-proxies';



@NgModule({
  providers: [
    AuthServiceProxy
  ]
})
export class ServiceProxyModule { }
