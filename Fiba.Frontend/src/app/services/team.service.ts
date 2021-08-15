import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Team } from "../models/Team";
import { AuthentificationService } from "./authentification.service";

@Injectable({
    providedIn: 'root'
})

export class TeamService {

    public teams: Team[];

    constructor(private httpClient: HttpClient, private authentification: AuthentificationService) { }

    getByGender(id : string): Observable<void> {
        return this.httpClient
            .get<Team[]>(`http://localhost:5001/api/genders/${id}/teams`)
            .pipe(map(data => {
                this.teams = data;
                return;
            }));
    }
}