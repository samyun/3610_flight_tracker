"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var index_1 = require("./components/home/index");
var index_2 = require("./components/login/index");
var index_3 = require("./components/register/index");
var index_4 = require("./components/_guards/index");
var index_5 = require("./components/test/index");
var index_6 = require("./components/flight/index");
var appRoutes = [
    { path: 'home', component: index_1.HomeComponent, canActivate: [index_4.AuthGuard] },
    { path: 'login', component: index_2.LoginComponent },
    { path: 'register', component: index_3.RegisterComponent },
    { path: '', component: index_5.TestComponent },
    { path: 'flight', component: index_6.FlightComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map