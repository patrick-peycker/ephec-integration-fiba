import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { SeasonsComponent } from './seasons/seasons.component';
import { SeasonComponent } from './season/season.component';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { LoginComponent } from './login/login.component';
import { AuthgardService } from './services/authgard.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { SeasonService } from './services/season.service';
import { TeamService } from './services/team.service';
import { TeamsComponent } from './teams/teams.component';
import { AgGridModule } from 'ag-grid-angular';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    TeamsComponent,
    HomeComponent,
    SeasonsComponent,
    SeasonComponent,
    LoginComponent,
    AuthCallbackComponent
  ],

  imports: [
    AgGridModule.withComponents([]),
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    NgbModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'home', component: HomeComponent },
      { path: 'teams', component: TeamsComponent },
      { path: 'login', component: LoginComponent },
      { path: 'seasons', component: SeasonsComponent },
      { path: 'auth-callback', component: AuthCallbackComponent}
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5000"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [
    SeasonService,
    TeamService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
