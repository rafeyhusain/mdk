import { Component, OnInit, AfterContentInit } from '@angular/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { authConfig } from './shared/models/auth-config.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, AfterContentInit {
    title = 'MDK';

    constructor(private oauthService: OAuthService) {
      this.configureWithNewConfigApi();
    }

    ngOnInit() {
    }

    ngAfterContentInit() {
    }

    private configureWithNewConfigApi() {
      this.oauthService.configure(authConfig);
      this.oauthService.tokenValidationHandler = new JwksValidationHandler();
      this.oauthService.loadDiscoveryDocumentAndTryLogin();
    }
}