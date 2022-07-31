import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { AdminGuard } from './auth/admin.guard';
import { AuthGuard } from './auth/auth.guard';
import { AuthService } from './auth/auth.service';
import { UnauthGuard } from './auth/unauth.guard';
import { SessionService } from './session/session.service';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";


@NgModule({
  providers: [
    AuthService,
    SessionService,
    AuthGuard,
    AdminGuard,
    UnauthGuard
  ],
  imports: [
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ]
})
export class ServicesModule { }
