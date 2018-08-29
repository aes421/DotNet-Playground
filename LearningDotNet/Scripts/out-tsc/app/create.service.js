var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var CreateService = /** @class */ (function () {
    function CreateService(http) {
        this.http = http;
    }
    CreateService.prototype.getStatuses = function () {
        return this.http.get("/CreateEdit/GetStatuses");
    };
    CreateService.prototype.postTask = function (name, statusId) {
        return this.http.post('/CreateEdit/CreateEdit', { Name: name, StatusId: statusId });
    };
    CreateService = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [HttpClient])
    ], CreateService);
    return CreateService;
}());
export { CreateService };
//# sourceMappingURL=create.service.js.map