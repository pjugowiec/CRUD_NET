import { EmployeeRestSerivce } from './rest/employee-rest.service';
import { NgModule } from '@angular/core';
import { LoginRestSerivce } from './rest/login-rest.service';

@NgModule({
    providers: [
        EmployeeRestSerivce,
        LoginRestSerivce
    ]
})
export class RestModule { }