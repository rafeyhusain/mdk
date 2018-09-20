import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-filter-checkbox',
  templateUrl: './filter-checkbox.component.html',
  styleUrls: ['./filter-checkbox.component.css']
})
export class FilterCheckboxComponent implements OnInit {
  @Input() caption: string;
  @Input() items: any[];

  constructor() { }

  ngOnInit() {
  }
}
