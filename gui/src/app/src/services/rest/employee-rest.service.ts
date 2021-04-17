import { EmployeeModify } from '../../model/external/EmployeeModify';
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

  queryGetAll(): Observable<Array<Employee>> {
    return this.request<Array<Employee>>({
      url: `${EMPLOYEE_URL}`,
      method: Method.GET
    });
  }

  queryGetOne(id: number): Observable<EmployeeModify> {
    return this.request<EmployeeModify>({
      url: `${EMPLOYEE_URL}` + '/' + id,
      method: Method.GET
    });
  }

  queryPost(employee: EmployeeModify): Observable<void> {
    return this.request<void>({
      url: `${EMPLOYEE_URL}`,
      data: employee,
      method: Method.POST
    });
  }

  queryPut(employee: EmployeeModify, id: number): Observable<void> {
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
