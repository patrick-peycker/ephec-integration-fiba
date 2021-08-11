import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';

import { AuthentificationService } from '../services/authentification.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authentification: AuthentificationService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void { }

  getIsAuth() { return this.authentification.isAuthenticate(); }

  onLogin() { return this.authentification.startAuthentication();}

  onLogout() { this.authentification.signOut(); }
}
