import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminGuard } from '../../shared/services/auth/admin.guard';
import { ProductComponent } from './product.component';
import { CreateProductComponent } from './create-product.component';

const routes: Routes = [
  {
    path: '',
    canActivate: [AdminGuard],
    component: ProductComponent,
    pathMatch: 'full',
  },
  {
    path: 'product/create',
    canActivate: [AdminGuard],
    component: CreateProductComponent,
    pathMatch: 'full',
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
