import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Gender } from '../models/gender';
import { GenderService } from '../services/gender.service';
import { TeamService } from '../services/team.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})

export class TeamsComponent implements OnInit {

  constructor(public teamService: TeamService, public genderService: GenderService) { }

  ngOnInit(): void {
    this.genderService.getAll().subscribe();
  }

  selectGender = new FormControl();

  getByGender() {
    this.teamService.getByGender(this.selectGender.value).subscribe();
  }
}
