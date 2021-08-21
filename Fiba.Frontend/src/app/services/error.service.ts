import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ErrorMessage } from '../models/errorMessage';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  error$ : BehaviorSubject<ErrorMessage>;
  
  constructor() { 
    this.error$ = new BehaviorSubject<ErrorMessage>(new ErrorMessage);
  }
}
