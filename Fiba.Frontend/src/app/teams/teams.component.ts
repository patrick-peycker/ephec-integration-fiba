import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Gender } from '../models/gender';
import { GenderService } from '../services/gender.service';
import { TeamService } from '../services/team.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})

export class TeamsComponent implements OnInit, OnDestroy {

  private genderIdSubscription: Subscription;

  constructor(public teamService: TeamService, public genderService: GenderService) { }

  ngOnInit(): void {
    this.genderIdSubscription = this.genderService.genderId$.subscribe((value) => { this.teamService.getByGender(value).subscribe(); });
  }

  ngOnDestroy(): void {
    this.genderIdSubscription.unsubscribe();
  }
}
