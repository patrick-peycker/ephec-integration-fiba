import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { Season } from '../models/season';
import { AuthentificationService } from './authentification.service';

@Injectable({
  providedIn: 'root'
})

export class SeasonService {

  public seasons: Season[];

  constructor(private httpClient: HttpClient, private authentification: AuthentificationService) { }

  getByGender(id: string): Observable<void> {
    return this.httpClient
      .get<Season[]>(`http://localhost:5001/api/genders/${id}/seasons`)
      .pipe(map(data => {
        this.seasons = data;
        return;
      }));
  }

  add(season: Season) : Observable<Season> {
    const token = this.authentification.getUser().access_token;
    return this.httpClient
      .post<Season>(
        `http://localhost:5001/api/genders/${season.genderId}/seasons`,
        JSON.stringify({ genderId: season.genderId, year: season.year }),
        { headers: new HttpHeaders({"Content-Type" : "application/json", "Authorization" : `Bearer ${token}`}) }
    )
  }
}
