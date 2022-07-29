import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { MainComponent } from './main/main.component';
import { MainModule } from './main/main.module';
import { UtilitiesModule } from './utilities/utilities.module';
import { AppRoutingModule } from './app-routing.module';
import { APP_INITIALIZER } from '@angular/core';
import { Injector } from '@angular/core';
import { PlatformLocation } from '@angular/common';
import { AppConsts } from './shared/app-consts';
import { environment } from '../environments/environment';
import { XmlHttpRequestHelper } from './shared/helpers/XmlHttpRequestHelper';
import { SessionService } from './shared/services/session/session.service';
import { API_BASE_URL, GetLoggedInUserDto } from './shared/service-proxies/service-proxies';
import { Router } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

export function appInitializerFactory(injector: Injector, platformLocation: PlatformLocation, router: Router) {

  return () => {

    return new Promise<boolean>((resolve, reject) => {
      AppConsts.appBaseHref = getBaseHref(platformLocation);
      let appBaseUrl = getDocumentOrigin() + AppConsts.appBaseHref;
      console.log(appBaseUrl);

      AppConsts.appBaseUrl = appBaseUrl;

      let type = 'GET';
      let url = appBaseUrl + 'assets/' + environment.appsettings;

      XmlHttpRequestHelper.ajax(type, url, null, null, (result: any) => {

        AppConsts.remoteServiceBaseUrl = result.remoteServiceBaseUrl;
        console.log(result.remoteServiceBaseUrl);

        let sessionService: SessionService = injector.get(SessionService);
        sessionService.init().then((user: GetLoggedInUserDto) => {
          // Do something with the user here

          resolve(true);
        }, (err: any) => {
          resolve(err);
        });

      });

    });
  }
}

export function getBaseHref(platformLocation: PlatformLocation): string {
  let baseUrl = platformLocation.getBaseHrefFromDOM();
  if (baseUrl) {
    return baseUrl;
  }

  return '/';
}

export function getDocumentOrigin() {
  if (!document.location.origin) {
    return document.location.protocol + '//' + document.location.hostname + (document.location.port ? ':' + document.location.port : '');
  }

  return document.location.origin;
}

export function getRemoteServiceBaseUrl() {
  return AppConsts.remoteServiceBaseUrl;
}


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    MainModule,
    SharedModule,
    UtilitiesModule,
    BrowserModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [
    { provide: API_BASE_URL, useFactory: getRemoteServiceBaseUrl },
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializerFactory,
      deps: [Injector, PlatformLocation, Router],
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
