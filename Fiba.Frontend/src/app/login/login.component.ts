import { Component, OnInit } from '@angular/core';
import { AuthentificationService } from '../services/authentification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authentification: AuthentificationService) { }

  ngOnInit(): void { }

  getIsAuth() { return this.authentification.isAuthenticate(); }

  onLogin() { return this.authentification.startAuthentication();}

  onLogout() { this.authentification.signOut(); }
}
