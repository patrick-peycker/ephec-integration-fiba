import { Component, Input, OnInit } from '@angular/core';
import { SeasonService } from '../services/season.service';

@Component({
  selector: 'app-season',
  templateUrl: './season.component.html',
  styleUrls: ['./season.component.css']
})
  
export class SeasonComponent implements OnInit {

  title = "Article";

  @Input() id: number;
  @Input() year: number;
  @Input() gender: number;
  @Input() nbTeams: number;

  constructor(private seasonService : SeasonService) { }

  ngOnInit(): void {
  }

}
