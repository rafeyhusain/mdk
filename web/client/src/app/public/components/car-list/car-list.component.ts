import { Component, OnInit, Input } from '@angular/core';
import { CarService } from '../../../services/car/car.service';
import { PagerService } from '../../../services/pager/pager.service';
import { CarModel } from '../../../shared/models/car.model';
import { CarPageModel } from '../../../shared/models/car-page.model';
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
  pager: any = {};
  pagedItems: any[];

  constructor(private carService: CarService, private pagerService: PagerService) { }

  ngOnInit() {
    this.setPage(1);
  }

  setPage(page: number) {
    this.filter.CurrentPage = page;
    this.filter.SortBy = 1;
    this.filter.PageSize = 10;

    this.carService.getCars(this.filter)
    .subscribe(carPage => this.setCarPage(carPage));
  }

  setCarPage(carPage: CarPageModel) {
    this.cars = carPage.Results
    this.pager = this.pagerService.getPager(this.cars.length, carPage.CurrentPage);
    this.pagedItems = this.cars.slice(this.pager.startIndex, this.pager.endIndex + 1);
  }
}