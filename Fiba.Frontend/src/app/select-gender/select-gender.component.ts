import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { GenderService } from '../services/gender.service';

@Component({
  selector: 'app-select-gender',
  templateUrl: './select-gender.component.html',
  styleUrls: ['./select-gender.component.css']
})

export class SelectGenderComponent implements OnInit {

  selectGender = new FormControl();

  constructor(public genderService: GenderService) { }

  ngOnInit(): void {
    this.genderService.getAll().subscribe();
  }

  getByGender() {
    this.genderService.genderId$.next(this.selectGender.value);
  }
}
