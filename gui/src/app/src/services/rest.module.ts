import { EmployeeRestSerivce } from './rest/employee-rest.service';
import { NgModule } from '@angular/core';

@NgModule({
    providers: [
        EmployeeRestSerivce
    ]
})
export class RestModule { }