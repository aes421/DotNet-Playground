var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
var ToDoFormComponent = /** @class */ (function () {
    function ToDoFormComponent(http) {
        this.http = http;
        this.task = new FormControl('');
        this.status = new FormControl('');
    }
    ToDoFormComponent.prototype.onSave = function () {
        this.http.get("/Home/GetStatuses").subscribe(function (data) {
            console.log(data);
        });
    };
    ToDoFormComponent = __decorate([
        Component({
            selector: 'app-to-do-form',
            templateUrl: './to-do-form.component.html',
            styleUrls: ['./to-do-form.component.css']
        }),
        __metadata("design:paramtypes", [HttpClient])
    ], ToDoFormComponent);
    return ToDoFormComponent;
}());
export { ToDoFormComponent };
//# sourceMappingURL=to-do-form.component.js.map