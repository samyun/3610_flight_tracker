import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
@Component({
    moduleId: module.id,

    selector: 'flight',
    templateUrl: 'flight.component.html'
})
export class FlightComponent {
    public flights: Flight;
      constructor(private http: Http) {
    }
 
    public getFlight(chosenCarrier: string, chosenNumber: string, chosenYear: string, chosenMonth: string, chosenDay:string, Departure: string) {
        this.http.get('/api/flights/'  + chosenCarrier + '/' + chosenNumber + '/' + chosenYear + '/' + chosenMonth + '/' + chosenDay + '/' + Departure).subscribe(result => {
            this.flights = result.json();
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
        postalCode: string;
        country: string;
        items?: any;
    }

    interface Flight {
        flightId: number;
        lastUpdated: Date;
        carrier: string;
        flightNumber: string;
        scheduledDepartureDate: Date;
        estimatedDepartureDate: Date;
        departureAirport: Airport;
        arrivalAirport: Airport;
    }


