import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AccountComponent } from './account/account.component';
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
    pathMatch: 'full',
  },
  {
    path: 'account',
    component: AccountComponent,
    loadChildren: () => import('./account/account.module').then(m => m.AccountModule),
    pathMatch: 'full'
  },
  {
    path: 'product',
    component: ProductComponent,
    loadChildren: () => import('./product/product.module').then(m => m.ProductModule),
    pathMatch: 'full'
  },
  {
    path: 'order',
    component: OrderComponent,
    loadChildren: () => import('./order/order.module').then(m => m.OrderModule),
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }
