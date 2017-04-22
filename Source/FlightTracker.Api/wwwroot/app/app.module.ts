import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { AppConfig } from './app.config';

import { AlertComponent } from './components/_directives/index';
import { AuthGuard } from './components/_guards/index';
import { AlertService, AuthenticationService } from './components/_services/index';
import { AuthHttp } from "./auth.http";
import { HomeComponent } from './components/home/index';
import { LoginComponent } from './components/login/index';
import { RegisterComponent } from './components/register/index';
import {TestComponent} from './components/test/index';
import {FlightComponent} from './components/flight/index';
import {AirportComponent} from './components/airport/index';


import {NavBarComponent} from './components/navbar/index';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        routing
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        HomeComponent,
        LoginComponent,
        TestComponent,
        NavBarComponent,
        FlightComponent,
        AirportComponent,
        RegisterComponent

    ],
    providers: [
        AppConfig,
        AuthGuard,
        AlertService,
        AuthenticationService,
        AuthHttp
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }