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
import { ReactiveFormsModule } from '@angular/forms';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { SeasonService } from './services/season.service';
import { TeamService } from './services/team.service';
import { TeamsComponent } from './teams/teams.component';
import { AgGridModule } from 'ag-grid-angular';
import { SelectGenderComponent } from './select-gender/select-gender.component';
import { GenderService } from './services/gender.service';
import { PlayersComponent } from './players/players.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SeasonCreateComponent } from './season-create/season-create.component';
import { MatchesComponent } from './matches/matches.component';

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
    AuthCallbackComponent,
    SelectGenderComponent,
    PlayersComponent,
    NotFoundComponent,
    SeasonCreateComponent,
    MatchesComponent
  ],

  imports: [
    AgGridModule.withComponents([]),
    ReactiveFormsModule,
    BrowserModule,
    NgbModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'home', component: HomeComponent },
      { path: 'seasons', component: SeasonsComponent },
      { path: 'matches/:id', component: MatchesComponent },
      { path: 'season-create', canActivate: [AuthgardService], component: SeasonCreateComponent },
      { path: 'teams', component: TeamsComponent },
      { path: 'players', component: PlayersComponent },
      { path: 'login', component: LoginComponent },
      { path: 'auth-callback', component: AuthCallbackComponent },
      { path: 'not-found', component: NotFoundComponent },
      { path: '**', redirectTo: 'not-found' }
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
    TeamService,
    GenderService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
