import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Season } from '../models/season';
import { AuthentificationService } from './authentification.service';

@Injectable({
  providedIn: 'root'
})
  
export class SeasonService {

  public seasons : Season[];
  
  constructor(private httpClient : HttpClient, private authentification : AuthentificationService){ }

  getAll() {
    const token = this.authentification.getUser().access_token;
    return this.httpClient.get<Season[]>("http://localhost:5001/api/seasons", { headers: new HttpHeaders({ "Authorization": "Bearer " + token })});
  }

  getByGender(id : string): Observable<void> {
    return this.httpClient
        .get<Season[]>(`http://localhost:5001/api/genders/${id}/seasons`)
        .pipe(map(data => {
            this.seasons = data;
            return;
        }));
      }
}
