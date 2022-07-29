import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AccountComponent } from './account/account.component';
import { ProductComponent } from './products/product.component';
import { OrderComponent } from './orders/order.component';
import { AuthGuard } from '../shared/services/auth/auth.guard';
import { AdminGuard } from '../shared/services/auth/admin.guard';
import { UnauthGuard } from '../shared/services/auth/unauth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {
    path: 'home',
    component: HomeComponent,
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
    pathMatch: 'full',
  },
  {
    path: 'account',
    canActivate: [UnauthGuard],
    component: AccountComponent,
    loadChildren: () => import('./account/account.module').then(m => m.AccountModule),
    pathMatch: 'full'
  },
  {
    path: 'product',
    component: ProductComponent,
    canActivate: [AdminGuard],
    loadChildren: () => import('./products/product.module').then(m => m.ProductModule),
    pathMatch: 'full'
  },
  {
    path: 'order',
    component: OrderComponent,
    canActivate: [AdminGuard],
    loadChildren: () => import('./orders/order.module').then(m => m.OrderModule),
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }
