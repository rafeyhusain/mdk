import { Component, OnInit } from '@angular/core';
import { CarFilterModel } from '../../../shared/models/car-filter.model';
import { OAuthService } from 'angular-oauth2-oidc';

declare let $: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  filter: CarFilterModel;

  constructor(private oauthService: OAuthService) {
  }

  ngOnInit() {
  }

  public login() {
      this.oauthService.initImplicitFlow();
  }

  public logoff() {
      this.oauthService.logOut();
  }

  public get name() {
      let claims = this.oauthService.getIdentityClaims();
      if (!claims) return null;
      console.log("claims", claims);
      return claims['name'];
  }
}
