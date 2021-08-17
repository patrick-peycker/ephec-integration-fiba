import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Season } from '../models/season';
import { SeasonsComponent } from '../seasons/seasons.component';
import { GenderService } from '../services/gender.service';
import { SeasonService } from '../services/season.service';

@Component({
  selector: 'app-season-create',
  templateUrl: './season-create.component.html',
  styleUrls: ['./season-create.component.css']
})
export class SeasonCreateComponent implements OnInit {

  public seasonForm : FormGroup;

  constructor(public genderService : GenderService, private seasonService : SeasonService, private formBuilder : FormBuilder) { }

  ngOnInit(): void {
    this.genderService.getAll().subscribe();
    this.seasonForm = this.formBuilder.group({
      gender: ['', Validators.required],
      year: ['', [Validators.required, Validators.min(2000), Validators.max(2050)]]
    });
  }

  onSubmit(){
    if (this.seasonForm.valid){
      const season = new Season();
      season.genderId = this.seasonForm.value.gender;
      season.year = +this.seasonForm.value.year;
      this.seasonService
        .add(season)
        .subscribe(
          content => {console.log(content)},
          error => {console.log(error)}
        );
    };
  }

}
