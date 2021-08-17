import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { GenderService } from '../services/gender.service';
import { SeasonService } from '../services/season.service';

@Component({
  selector: 'app-seasons',
  templateUrl: './seasons.component.html',
  styleUrls: ['./seasons.component.css']
})

export class SeasonsComponent implements OnInit, OnDestroy {

  private genderIdSubscription: Subscription;

  constructor(public seasonService: SeasonService, public genderService: GenderService) { }

  ngOnInit(): void {
    this.genderIdSubscription = this.genderService.genderId$.subscribe((value) => { this.seasonService.getByGender(value).subscribe(); });
  }

  ngOnDestroy(): void {
    this.genderIdSubscription.unsubscribe();
  }
}
