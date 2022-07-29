import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login.component';
import { UnauthGuard } from '../../shared/services/auth/unauth.guard';
import { RegisterComponent } from './register.component';



const routes: Routes = [
  {
    path: 'account/login',
    canActivate: [UnauthGuard],
    component: LoginComponent,
    pathMatch: 'full',
  },
  {
    path: 'account/register',
    canActivate: [UnauthGuard],
    component: RegisterComponent,
    pathMatch: 'full',
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
