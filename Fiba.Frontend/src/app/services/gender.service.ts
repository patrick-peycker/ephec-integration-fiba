import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Gender } from '../models/gender';

@Injectable({
  providedIn: 'root'
})

export class GenderService {

  public genders: Gender[];
  genderId$ : BehaviorSubject<string>;

  constructor(private httpClient: HttpClient) { 
    this.genderId$ = new BehaviorSubject<string>(null);
  }

  getAll(): Observable<void> {
    return this.httpClient
      .get<Gender[]>("http://localhost:5001/api/genders")
      .pipe(map(data => {
        this.genders = data;
        return;
      }));
  }
}
