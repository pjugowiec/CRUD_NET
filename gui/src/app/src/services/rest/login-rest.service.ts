import { LoginForm } from './../../model/external/LoginForm';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Method, RestService } from "../rest.service";
import { Observable } from 'rxjs';


const LOGIN_URL = '/login';

@Injectable()
export class LoginRestSerivce extends RestService {

    constructor(http: HttpClient) {
        super(http);
    }

    queryPost(loginForm: LoginForm): Observable<void> {
        return this.request<void>({
            url: `${LOGIN_URL}`,
            data: loginForm,
            method: Method.POST
        });
    }

}