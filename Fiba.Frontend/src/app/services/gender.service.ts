import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Gender } from '../models/gender';

@Injectable({
  providedIn: 'root'
})

export class GenderService {

  public genders: Gender[];

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<void> {
    return this.httpClient
      .get<Gender[]>("http://localhost:5001/api/genders")
      .pipe(map(data => {
        this.genders = data;
        return;
      }));
  }
}
