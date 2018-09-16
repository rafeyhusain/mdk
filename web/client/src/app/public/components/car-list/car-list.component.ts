import { Component, OnInit } from '@angular/core';
import { CarService } from '../../../services/car/car.service';
import { CarModel } from '../../../shared/models/car.model';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  cars: CarModel[];
  totalPages: number;
  activePage: number;
  
  constructor(private carService: CarService) { }

  ngOnInit() {
    this.getCars();
  }

  getCars(): void {
    this.carService.getCars()
    .subscribe(cars => this.cars = cars);
  }
}
