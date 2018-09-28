import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
  issuer: 'https://accounts.google.com',
  redirectUri: window.location.origin + '/index.html',
  clientId: '{facebook, google etc. client id}',
  scope: 'openid profile email',
  strictDiscoveryDocumentValidation: false
}


