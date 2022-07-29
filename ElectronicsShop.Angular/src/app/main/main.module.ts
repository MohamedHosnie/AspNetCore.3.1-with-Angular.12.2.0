import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { AccountModule } from './account/account.module';
import { HomeModule } from './home/home.module';
import { OrderModule } from './orders/order.module';
import { ProductModule } from './products/product.module';
import { LayoutModule } from '../layout/layout.module';
import { MainRoutingModule } from './main-routing.module';



@NgModule({
  declarations: [
    MainComponent
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
    LayoutModule,
    AccountModule,
    HomeModule,
    OrderModule,
    ProductModule
  ],
  exports: [
    MainComponent
  ]
})
export class MainModule { }
