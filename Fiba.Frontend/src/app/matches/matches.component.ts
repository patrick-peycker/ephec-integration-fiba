import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatchService } from '../services/match.service';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.css']
})
export class MatchesComponent implements OnInit {

  constructor(public matchService : MatchService, public router : Router) { }

  ngOnInit(): void {
    const id = this.router.url.slice(9);
    this.matchService.getBySeason(id).subscribe();
  }
}
