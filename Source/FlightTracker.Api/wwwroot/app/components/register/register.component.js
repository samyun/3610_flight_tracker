"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var router_1 = require("@angular/router");
var index_1 = require("../_services/index");
var RegisterComponent = (function () {
    function RegisterComponent(fb, router, authService) {
        this.fb = fb;
        this.router = router;
        this.authService = authService;
        this.title = "Register";
        this.registrationForm = null;
        this.registrationError = false;
        if (this.authService.isLoggedIn()) {
            this.router.navigate([""]);
        }
        this.registrationForm = fb.group({
            name: ["", forms_1.Validators.required],
            email: ["", forms_1.Validators.required],
            password: ["", forms_1.Validators.required]
        });
    }
    RegisterComponent.prototype.performRegistration = function (e) {
        var _this = this;
        e.preventDefault();
        var name = this.registrationForm.value.name;
        var email = this.registrationForm.value.email;
        var password = this.registrationForm.value.password;
        this.authService.register(name, email, password)
            .subscribe(function (data) {
            // registration successful
            _this.registrationError = false;
            alert("Registration successful!");
            _this.router.navigate([""]);
        }, function (err) {
            console.log(err);
            // registration error
            _this.registrationError = true;
        });
    };
    return RegisterComponent;
}());
RegisterComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        templateUrl: 'register.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder,
        router_1.Router,
        index_1.AuthenticationService])
], RegisterComponent);
exports.RegisterComponent = RegisterComponent;
//# sourceMappingURL=register.component.js.map