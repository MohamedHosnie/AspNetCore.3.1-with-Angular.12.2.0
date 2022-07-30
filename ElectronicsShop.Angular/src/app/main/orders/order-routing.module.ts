import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminGuard } from '../../shared/services/auth/admin.guard';
import { OrderComponent } from './order.component';
import { AuthGuard } from '../../shared/services/auth/auth.guard';
import { CreateOrderComponent } from './create-order.component';



const routes: Routes = [
  {
    path: '',
    canActivate: [AdminGuard],
    component: OrderComponent,
    pathMatch: 'full',
  },
  {
    path: 'order/create',
    canActivate: [AuthGuard],
    component: CreateOrderComponent,
    pathMatch: 'full',
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule { }
