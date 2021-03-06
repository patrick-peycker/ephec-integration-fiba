import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { GenderService } from '../services/gender.service';
import { PlayerService } from '../services/player.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})

export class PlayersComponent implements OnInit, OnDestroy {

  columnDefs = [
    { field: 'PlayerId' },
    { field: 'FirstName' },
    { field: 'LastName' },
    { field: 'Position' },
    { field: 'GenderId' },
    { field: 'Gender' }
  ];

  rowData = this.playerService.players;

  private genderIdSubscription: Subscription;

  constructor(public playerService: PlayerService, public genderService: GenderService) { }

  ngOnInit(): void {
    this.genderIdSubscription = this.genderService.genderId$.subscribe((value) => { this.playerService.getByGender(value).subscribe(); });
  }

  ngOnDestroy(): void {
    this.genderIdSubscription.unsubscribe();
  }
}
