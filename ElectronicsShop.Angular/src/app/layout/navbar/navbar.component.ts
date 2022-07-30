import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Role } from '../../shared/app-enums';
import { Emitters } from '../../shared/emitters/emitters';
import { UserDto } from '../../shared/service-proxies/service-proxies';
import { AuthService } from '../../shared/services/auth/auth.service';
import { SessionService } from '../../shared/services/session/session.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  applicationName = "Electronics Shop";
  isAuthenticated = false;
  username = "";
  isAdmin = false;

  constructor(
    private authService: AuthService,
    private sessionService: SessionService
  ) { }

  ngOnInit(): void {
    let user = this.sessionService.user as UserDto;
    if (user != null) {
      this.isAuthenticated = true;
      this.username = user.username as string;
      this.isAdmin = user.role == Role.Admin;
    }

    Emitters.userDataEmitter.subscribe(user => {
      if (user != null) {
        this.isAuthenticated = true;
        this.username = user.username as string;
        this.isAdmin = user.role == Role.Admin;
      } else {
        this.isAuthenticated = false;
        this.isAdmin = false;
        this.username = "";
      }
      
    });
  }

  logout() {
    this.authService.logout();
  }
}
