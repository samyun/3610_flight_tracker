import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
      moduleId: module.id,

  selector: 'airport',
  templateUrl: './airport.component.html'
})
export class AirportComponent {

      model: any = {};
      returnUrl: 'test'

          constructor(
        private route: ActivatedRoute,
        private router: Router) { }


    airportSearch() {this.model.airport
      this.router.navigate([this.returnUrl]);


} 

