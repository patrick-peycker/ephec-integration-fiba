import { ImplicitReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ErrorMessage } from './models/errorMessage';
import { ErrorService } from './services/error.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Fiba';

  public errorSubscription : Subscription;
  public errorMessage : ErrorMessage;

  constructor(private errorService : ErrorService) { }

  ngOnInit(): void {
    this.errorSubscription = this.errorService.error$.subscribe((value) => this.errorMessage = value);
  }
}
