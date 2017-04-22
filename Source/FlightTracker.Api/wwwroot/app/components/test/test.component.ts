import { Component } from '@angular/core';
import { AuthenticationService } from '../_services/index';
import { Router } from '@angular/router';

@Component({
     moduleId: module.id,

    selector: 'test',

    templateUrl: 'test.component.html',
    styleUrls: ['test.component.css']

})
export class TestComponent {
    constructor(public router: Router, public authService: AuthenticationService) { }

    isActive(data: any[]): boolean { 
        return this.router.isActive(this.router.createUrlTree(data), true); 
    }
    
    logout(): boolean {
        // logs out the user, then redirects him to Welcome View.
        if (this.authService.logout()) {
            this.router.navigate([""]);
        }
        return false;
    }
}