import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService, AuthenticationService } from '../_services/index';

@Component({
    moduleId: module.id,
    templateUrl: 'login.component.html'
})

export class LoginComponent {
    title = "Login";
    loginForm = null;
    loginError = false;
    constructor(
        private fb: FormBuilder,
        private router: Router,
        private authService: AuthenticationService) {
        if (this.authService.isLoggedIn()) {
            this.router.navigate([""]);
        }
        this.loginForm = fb.group({
            email: ["", Validators.required],
            password: ["", Validators.required]
        });
    }
    performLogin(e) {
        e.preventDefault();
        var email = this.loginForm.value.email;
        var password = this.loginForm.value.password;
        this.authService.login(email, password)
            .subscribe((data) => {
                // login successful
                this.loginError = false;
                alert("Logged in!");
                this.router.navigate([""]);
            },
            (err) => {
                console.log(err);
                // login failure
                this.loginError = true;
            });
    }
}