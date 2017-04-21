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
 
    public getFlight(chosenCarrier: string, chosenNumber: string, chosenYear: string, chosenMonth: string, chosenDay:string) {
        this.http.get('/api/flights/'  + chosenCarrier + '/' + chosenNumber + '/' + chosenYear + '/' + chosenMonth + '/' + chosenDay).subscribe(result => {
            this.flights = result.json();
        });
    }
}
    
interface Flight {
  FlightId: Number;
  LastUpdated: Date;
  Carrier: string;
  FlightNumber: string;
  ScheduledDepartureDate: Date;
  EstimatedDepartureDate: Date;
  DepartureAirport: string;
  ScheduledArrivalDated: Date;
  EstimatedArrivalDated: Date;
  ArrivalAirport: string;
  Status: string;
  DepartureGate: string;
  ArrivalGate: string;
  DepartureTerminal: string;
  ArrivalTerminal: string;
  BaggageClaim: string;
}