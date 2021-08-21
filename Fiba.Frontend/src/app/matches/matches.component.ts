import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { from } from 'rxjs';
import { groupBy, mergeMap, toArray } from 'rxjs/operators';
import { MatchService } from '../services/match.service';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.css']
})
export class MatchesComponent implements OnInit {

  public rounds : number[];

  constructor(public matchService: MatchService, public router: Router) {
  }

  ngOnInit(): void {
    const id = this.router.url.slice(9);
    this.matchService.getBySeason(id).subscribe();
    //from(this.matchService.matches).pipe(groupBy(m => m.round)).subscribe((value) => {console.log(value);});
  }
}
