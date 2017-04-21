import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  moduleId: module.id,

  selector: 'airport',
  templateUrl: 'airport.component.html'
})
export class AirportComponent  {
  public airports: Airport;
    constructor(http: Http) {
        http.get('/api/airports/CMH').subscribe(result => {
            this.airports = result.json();
        });
    }
}
interface Airport {
   airportId: string;
  iataCode: string;
  name: string;
  address: string;
  city: string;
  state: string;
  postalCode: number;
  country: string;
  items: string;
}