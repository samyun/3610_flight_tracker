import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
@Component({
    moduleId: module.id,

    selector: 'flight',
    templateUrl: 'flight.component.html'
})
export class FlightComponent {
    public flights: Flight.RootObject;
    public flights2: Flight.ArrivalAirport;

      constructor(private http: Http) {
    }
 
    public getFlight(chosenCarrier: string, chosenNumber: string, chosenYear: string, chosenMonth: string, chosenDay:string, Departure: string) {
        this.http.get('/api/flights/'  + chosenCarrier + '/' + chosenNumber + '/' + chosenYear + '/' + chosenMonth + '/' + chosenDay + '/' + Departure).subscribe(result => {
            this.flights = result.json();
            this.flights2 = this.flights.arrivalAirport;
        });
    }
}
    


      declare module Flight {

    export interface DepartureAirport {
        airportId: string;
        iataCode: string;
        name: string;
        address: string;
        city: string;
        state: string;
        postalCode: string;
        country: string;
        items: any[];
    }

    export interface ArrivalAirport {
        airportId: string;
        iataCode: string;
        name: string;
        address?: any;
        city: string;
        state?: any;
        postalCode?: any;
        country: string;
        items: any[];
    }

    export interface RootObject {
        flightId: number;
        lastUpdated: Date;
        carrier: string;
        flightNumber: string;
        scheduledDepartureDate: Date;
        estimatedDepartureDate: Date;
        departureAirport: DepartureAirport;
        scheduledArrivalDate: Date;
        estimatedArrivalDate: Date;
        arrivalAirport: ArrivalAirport;
        status: string;
        departureGate: string;
        arrivalGate?: any;
        departureTerminal?: any;
        arrivalTerminal?: any;
        baggageClaim?: any;
    }

}

