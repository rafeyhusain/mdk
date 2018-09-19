import { Component, OnInit, Input } from '@angular/core';
import { CarModel } from '../../../shared/models/car.model';
import * as $ from 'jquery';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {
  @Input() car: CarModel;

  constructor() { }

  ngOnInit() {
  }

}
