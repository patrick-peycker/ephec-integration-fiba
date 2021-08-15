import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { take } from 'rxjs/operators';
import { Season } from '../models/season';
import { GenderService } from '../services/gender.service';
import { SeasonService } from '../services/season.service';

@Component({
  selector: 'app-seasons',
  templateUrl: './seasons.component.html',
  styleUrls: ['./seasons.component.css']
})

export class SeasonsComponent implements OnInit {

  constructor(public seasonService : SeasonService, public genderService : GenderService) { }

  ngOnInit(): void {
      this.genderService.getAll().subscribe();
  }

  selectGender = new FormControl();

  getByGender() {
    this.seasonService.getByGender(this.selectGender.value).subscribe();
  }
}
