import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Player } from '../models/player';
import { GenderService } from './gender.service';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  public players : Player[]

  constructor(private httpClient : HttpClient) { 
    
  }

  getByGender(id : string): Observable<void> {
    return this.httpClient
        .get<Player[]>(`http://localhost:5001/api/genders/${id}/players`)
        .pipe(map(data => {
            this.players = data;
            return;
        }));
}
}
