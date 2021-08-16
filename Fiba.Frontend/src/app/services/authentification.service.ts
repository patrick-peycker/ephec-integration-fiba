import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map, tap } from 'rxjs/operators';
import { UserManager, User, UserManagerSettings, WebStorageStateStore } from 'oidc-client';

@Injectable({
  providedIn: 'root'
})


export class AuthentificationService {

  private isAuth : boolean;
  private manager: UserManager;
  private user: User = null;
  
  constructor(private jwtHelper: JwtHelperService, private http: HttpClient)
  {
    this.isAuth = false;
    this.manager = new UserManager(this.getClientSettings());
    this.manager
      .getUser()
      .then(
        user =>
        {
          this.user = user;
        }
    )
    .catch(
      error => {
        console.log('Authentication Service : ' + error);
      }
    );
   }

  
  private getClientSettings(): UserManagerSettings {
    return {
      // url IS
      authority: 'http://localhost:5000',
      // client id dans IS
      client_id: 'fiba.frontend',
      // url app Angular au retour d'IS
      redirect_uri: 'http://localhost:4200/auth-callback',
      // le type de réponse
      response_type: "code",
      // les scopes
      scope: "openid profile fiba.api",
      // url app Angular au retour d'IS après logout (attention AccountOptions à modifier dans IS)
      post_logout_redirect_uri: 'http://localhost:4200/',
      // pour save le user dans localStorage
      userStore: new WebStorageStateStore({ store: window.localStorage })
    };
  }

  isAuthenticate() { 
    return this.user != null && !this.user.expired;
  }

  startAuthentication() { 
    return this.manager.signinRedirect(); 
  }

  completeAuthentication() {
    return this.manager.signinRedirectCallback().then(user => {
      this.user = user;
      });
  }
  
  signOut() {
    return this.manager.signoutRedirect();
  }
  
  getUser() {
    return this.user;
  }
}
