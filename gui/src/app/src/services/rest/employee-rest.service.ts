import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../../model/external/Employee';
import { Method, RestService } from './../rest.service';

const EMPLOYEE_URL = '/employee';
@Injectable()
export class EmployeeRestSerivce extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  queryGet(): Observable<Array<Employee>> {
    return this.request<Array<Employee>>({
      url: `${EMPLOYEE_URL}`,
      method: Method.GET
    });
  }

  queryEmployee(id: number): Observable<Employee> {
    return this.request<Employee>({
      url: `${EMPLOYEE_URL}` + '/' + id,
      method: Method.POST
    });
  }

  queryPost(employee: Employee): Observable<void> {
    return this.request<void>({
      url: `${EMPLOYEE_URL}`,
      data: employee,
      method: Method.POST
    });
  }

  queryPut(employee: Employee, id: number): Observable<void> {
    return this.request<void>({
      url: `${EMPLOYEE_URL}` + '/' + id,
      data: employee,
      method: Method.PUT
    });
  }

  queryDelete(id: number): Observable<void> {
    return this.request<void>({
      url: `${EMPLOYEE_URL}` + '/' + id,
      method: Method.DELETE
    });
  }
}
