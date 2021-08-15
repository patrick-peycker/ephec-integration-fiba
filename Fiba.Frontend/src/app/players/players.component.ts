import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { GenderService } from '../services/gender.service';
import { PlayerService } from '../services/player.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {

  constructor(public playerService : PlayerService, public genderService : GenderService) { }

  ngOnInit(): void {
    this.genderService.getAll().subscribe();
  }

  selectGender = new FormControl();

  getByGender() {
    this.playerService.getByGender(this.selectGender.value).subscribe();
  }

}
