import { Component } from '@angular/core';
import { AirportComponent }    from '../airport/airport.component';
@Component({
      moduleId: module.id,

  selector: 'airport-form',
  templateUrl: './airport-form.component.html'
})
export class AirportFormComponent {
  powers = ['Really Smart', 'Super Flexible',
            'Super Hot', 'Weather Changer'];
  submitted = false;
  onSubmit() { this.submitted = true; }
  newHero() {
  }
}