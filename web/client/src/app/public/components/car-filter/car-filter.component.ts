import { Component, OnInit, Input } from '@angular/core';
import { CarFilterModel } from '../../../shared/models/car-filter.model';
import { OptionsModel } from '../../../shared/models/options.model';
import { CarService } from '../../../services/car/car.service';

declare let $: any;

@Component({
  selector: 'app-car-filter',
  templateUrl: './car-filter.component.html',
  styleUrls: ['./car-filter.component.css']
})
export class CarFilterComponent implements OnInit {
  filter: CarFilterModel;
  options: OptionsModel;
  
  constructor(private carService: CarService) { }

  ngOnInit() {
    this.filter = new CarFilterModel();
    this.filter.SortBy = 1;

    this.carService.getOptions()
    .subscribe(options => this.options = options);

    console.log('OPTIONS', this.options);
  }
}
