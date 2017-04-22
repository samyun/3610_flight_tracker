import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService, AuthenticationService } from '../_services/index';

@Component({
    moduleId: module.id,
    templateUrl: 'register.component.html'
})

export class RegisterComponent {
    title = "Register";
    registrationForm = null;
    registrationError = false;
    constructor(
        private fb: FormBuilder,
        private router: Router,
        private authService: AuthenticationService) {
        if (this.authService.isLoggedIn()) {
            this.router.navigate([""]);
        }
        this.registrationForm = fb.group({
            name: ["", Validators.required],
            email: ["", Validators.required],
            password: ["", Validators.required]
        });
    }
    performRegistration(e) {
        e.preventDefault();
        var name = this.registrationForm.value.name;
        var email = this.registrationForm.value.email;
        var password = this.registrationForm.value.password;
        this.authService.register(name, email, password)
            .subscribe((data) => {
                // registration successful
                this.registrationError = false;
                alert("Registration successful!");
                this.router.navigate([""]);
            },
            (err) => {
                console.log(err);
                // registration error
                this.registrationError = true;
            });
    }
}
