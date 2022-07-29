import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServiceProxyModule } from './service-proxies/service-proxy.module';
import { ServicesModule } from './services/services.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ServiceProxyModule,
    ServicesModule
  ],
  exports: [
    ServiceProxyModule,
    ServicesModule
  ]
})
export class SharedModule { }
