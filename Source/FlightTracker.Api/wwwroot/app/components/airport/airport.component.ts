import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import {FormControl, FormGroup} from '@angular/forms';

@Component({
  moduleId: module.id,

  selector: 'airport',
  templateUrl: 'airport.component.html'
})
export class AirportComponent  {
 
  public airports: Airport;
      constructor(private http: Http) {
    }
 
    public getAirport(chosenAirport: string, mySite: string) {
        this.http.get('/api/airports/' + chosenAirport + '/' + mySite).subscribe(result => {
            this.airports = result.json();
        });
    }
}



   interface Item {
        itemId: string;
        airportID: string;
        type: string;
        name: string;
        phone?: any;
        address: string;
        description: string;
    }
interface Airport {
        airportId: string;
        iataCode: string;
        name: string;
        address: string;
        city: string;
        state: string;
        postalCode: string;
        country: string;
        items: Item[];
    }



