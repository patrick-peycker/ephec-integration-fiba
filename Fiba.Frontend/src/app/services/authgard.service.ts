import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AuthentificationService } from './authentification.service';

@Injectable({
  providedIn: 'root'
})
  
export class AuthgardService {

  constructor(private authentification: AuthentificationService, private router: Router) {  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.authentification.isAuthenticate()) { return true; }
    localStorage.setItem('path-redirect',state.url);
    this.authentification.startAuthentication();
    return false;
  }
}
