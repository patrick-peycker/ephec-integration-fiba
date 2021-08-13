import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Team } from "../models/Team";
import { AuthentificationService } from "./authentification.service";

@Injectable()

export class TeamService {

    public teams: Team[];

    constructor(private httpClient: HttpClient, private authentification: AuthentificationService) { }

    getAll(): Observable<void> {
        return this.httpClient
            .get<Team[]>("http://localhost:5001/api/teams")
            .pipe(map(data => {
                this.teams = data;
                return;
            }));
    }
}