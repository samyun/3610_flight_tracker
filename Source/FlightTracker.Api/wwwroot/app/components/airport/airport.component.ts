import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormControl, FormGroup } from '@angular/forms';
import {Router} from '@angular/router';



@Component({
    moduleId: module.id,

    selector: 'airport',
    templateUrl: 'airport.component.html'
})
export class AirportComponent {
    mySite: string = 'all';
    public airports: Airport.RootObject;
    constructor(private http: Http) {
    }

    public getAirport(chosenAirport: string, mySite: string) {
        if (mySite = 'all'){
            mySite = ''
        }
        this.http.get('/api/airports/' + chosenAirport + '/' + mySite).subscribe(result => {
            this.airports = result.json();
        });
    }
    
    public goHere(dest: string){
          this.http.get('/api/airports/items/item' + dest).subscribe(result => {
            this.airports = result.json();
        });
        
    }
        

  

}


declare module Airport {

    export interface Item {
        itemId: string;
        airportID: string;
        type: string;
        name: string;
        phone: string;
        address: string;
        description: string;
    }

    export interface RootObject {
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

}

