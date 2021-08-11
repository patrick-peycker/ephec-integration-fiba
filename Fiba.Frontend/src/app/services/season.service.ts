import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Season } from '../models/season';
import { AuthentificationService } from './authentification.service';

@Injectable({
  providedIn: 'root'
})
  
export class SeasonService {

  constructor(private httpClient : HttpClient, private authentification : AuthentificationService){ }

  getAll() {
    const token = this.authentification.getUser().access_token;
    return this.httpClient.get<Season[]>("http://localhost:5001/api/seasons", { headers: new HttpHeaders({ "Authorization": "Bearer " + token })});
  }
}
