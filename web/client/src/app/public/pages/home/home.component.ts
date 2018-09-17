import { Component, OnInit } from '@angular/core';
import { CarFilterModel } from '../../../shared/models/car-filter.model';

import * as $ from 'jquery';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  filter: CarFilterModel;

  constructor() { }

  ngOnInit() {
  }

}
