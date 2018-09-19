import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent implements OnInit {
  @Input() pager: any = {};
  @Output() onSetPage: EventEmitter<number> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  setPage(pageNo: number) {
    this.onSetPage.emit(pageNo);
  }
}
