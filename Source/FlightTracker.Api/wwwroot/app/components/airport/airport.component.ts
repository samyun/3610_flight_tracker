import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { AirportService } from '../_services/index';

@Component({
  moduleId: module.id,

  selector: 'airport',
  template: `My Values: <ul><li *ngFor="let value of values">
        <span>{{airportId}} </span>
      </li></ul>`,
  providers: [AirportService]
})
export class AirportComponent implements OnInit {
  public values: any[];
  constructor(private _dataService: AirportService) { }
  ngOnInit() {
    this._dataService
      .GetAll()
      .subscribe(data => this.values = data,
      error => console.log(error),
      () => console.log('Get all complete'));
  }
}