import { Component, OnInit } from '@angular/core';
import { GenderService } from '../services/gender.service';

@Component({
  selector: 'app-select-gender',
  templateUrl: './select-gender.component.html',
  styleUrls: ['./select-gender.component.css']
})

export class SelectGenderComponent implements OnInit {

  constructor(public genderService: GenderService) { }

  ngOnInit(): void {
    this.genderService.getAll().subscribe();
  }
}
