import { Component, OnInit } from '@angular/core';
import { CarFilterModel } from '../../../shared/models/car-filter.model';

import * as $ from 'jquery';

@Component({
  selector: 'app-car-filter',
  templateUrl: './car-filter.component.html',
  styleUrls: ['./car-filter.component.css']
})
export class CarFilterComponent implements OnInit {
  filter: CarFilterModel;

  constructor() { }

  ngOnInit() {
    this.filter = new CarFilterModel();
    this.filter.SortBy = 1;
  }
}
