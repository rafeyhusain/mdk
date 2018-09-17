import { Component, OnInit, Input } from '@angular/core';
import { CarService } from '../../../services/car/car.service';
import { CarModel } from '../../../shared/models/car.model';
import { CarFilterModel } from '../../../shared/models/car-filter.model';
import * as $ from 'jquery';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  @Input() filter: CarFilterModel;

  cars: CarModel[];
  
  constructor(private carService: CarService) { }

  ngOnInit() {
    this.getCars();
  }

  getCars(): void {
    this.carService.getCar(1)
    .subscribe(car => console.log(car));

    // this.carService.getCars(this.filter)
    // .subscribe(cars => this.cars = cars);
  }
}
