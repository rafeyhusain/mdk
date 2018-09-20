import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-filter-slider',
  templateUrl: './filter-slider.component.html',
  styleUrls: ['./filter-slider.component.css']
})
export class FilterSliderComponent implements OnInit {
  @Input() caption: string;
  @Input() items: any[];

  constructor() { }

  ngOnInit() {
  }
}