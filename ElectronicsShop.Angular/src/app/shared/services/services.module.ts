import { NgModule } from '@angular/core';
import { AdminGuard } from './auth/admin.guard';
import { AuthGuard } from './auth/auth.guard';
import { AuthService } from './auth/auth.service';
import { UnauthGuard } from './auth/unauth.guard';
import { SessionService } from './session/session.service';


@NgModule({
  providers: [
    AuthService,
    SessionService,
    AuthGuard,
    AdminGuard,
    UnauthGuard
  ]
})
export class ServicesModule { }