import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Match } from '../models/match';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  public matches: Match[]

  constructor(private httpClient: HttpClient) {
  }

  getBySeason(id: string): Observable<void> {
    return this.httpClient
      .get<Match[]>(`http://localhost:5001/api/seasons/${id}/matches`)
      .pipe(map(data => {
        this.matches = data;
        return;
      }));
  }
}
