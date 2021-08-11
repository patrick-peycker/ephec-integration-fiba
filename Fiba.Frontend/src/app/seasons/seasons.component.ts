import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Season } from '../models/season';
import { SeasonService } from '../services/season.service';

@Component({
  selector: 'app-seasons',
  templateUrl: './seasons.component.html',
  styleUrls: ['./seasons.component.css']
})
export class SeasonsComponent implements OnInit {

  seasons: Season[];

  constructor(private seasonService : SeasonService) { }

  ngOnInit(): void {
    this.seasonService.getAll().pipe(take(1)).subscribe(
      (content) => {this.seasons = content}
    )
  }

}
