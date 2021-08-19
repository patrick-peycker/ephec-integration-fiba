import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Season } from '../models/season';
import { SeasonTeam } from '../models/seasonTeam';
import { GenderService } from '../services/gender.service';
import { SeasonService } from '../services/season.service';
import { TeamService } from '../services/team.service';

@Component({
  selector: 'app-season-create',
  templateUrl: './season-create.component.html',
  styleUrls: ['./season-create.component.css']
})
export class SeasonCreateComponent implements OnInit, OnDestroy {

  public seasonForm: FormGroup;
  public seasonAdded: boolean = false;
  public season: Season = new Season();
  private genderIdSubscription: Subscription;
  public teamIds: number[] = [];

  constructor(public genderService: GenderService, public seasonService: SeasonService, public teamService: TeamService, private formBuilder: FormBuilder) { }


  ngOnInit(): void {
    this.genderService.getAll().subscribe();
    this.genderIdSubscription = this.genderService.genderId$.subscribe((value) => { if (value) { this.teamService.getByGender(value).subscribe(); } });

    this.seasonForm = new FormGroup({
      gender: new FormControl('', Validators.required),
      year: new FormControl('', [Validators.required, Validators.min(2000), Validators.max(2050)]),
    });
  }

  ngOnDestroy(): void {
    this.genderIdSubscription.unsubscribe();
  }

  get gender() { return this.seasonForm.get('gender'); }

  get year() { return this.seasonForm.get('year'); }

  getByGender() {
    this.genderService.genderId$.next(this.seasonForm.value.gender);
    this.teamIds = [];
  }

  onChangeTeam(e) {
    if (e.target.checked) {
      this.teamIds.push(+e.target.value);
    } else {
      const index = this.teamIds.findIndex(t => t.valueOf == e.target.value);
      this.teamIds.splice(index, 1);
    }
  }

  onSubmit() {
    if (this.seasonForm.valid) {
      this.season.genderId = this.seasonForm.value.gender;
      this.season.year = +this.seasonForm.value.year;

      for (let index = 0; index < this.teamIds.length; index++) {
        let seasonTeam: SeasonTeam = new SeasonTeam();
        seasonTeam.teamId = this.teamIds[index];
        this.season.seasonTeams.push(seasonTeam);
      }

      this.seasonService
        .add(this.season)
        .subscribe(
          content => { 
            this.season = content;
            console.log(this.season);
          },
          error => { console.log(error) },
          () => { this.seasonAdded = true; }
        );
      }

  }
}
