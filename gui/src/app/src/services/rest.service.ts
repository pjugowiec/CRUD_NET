import { HttpClient, HttpHeaders, HttpParameterCodec, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export enum Method {
    GET = 'GET',
    POST = 'POST',
    PUT = 'PUT',
    DELETE = 'DELETE'
}

class HttpValueEncoder implements HttpParameterCodec {
    decodeKey (key: string): string {
        return key;
    }

    decodeValue (value: string): string {
        return decodeURIComponent(value);
    }

    encodeKey (key: string): string {
        return key;
    }

    encodeValue (value: string): string {
        return encodeURIComponent(value);
    }
}

export class Resource {
    url: string;
    method: Method;
    data?: Object;
    form?: Object;
    params?: Object;
    encode?: boolean;
    headers?: Object;
    responseType?: 'arraybuffer' | 'blob' | 'text' | 'json' | 'image/png';
    observe?: 'body' | 'events' | 'response';
}

export class RestService {
    constructor (protected http: HttpClient) { }

    private url (resource: Resource): string {
        if (resource.url.startsWith('http') || resource.url.startsWith('www')) {
            return resource.url;
        }
        return `${environment.serviceApiUrl}${resource.url}`;
    }

    private params (data: Object): HttpParams {
        let params = new HttpParams({
            encoder: new HttpValueEncoder()
        });
        if (data) {
            Object.keys(data)
                .forEach((key) => {
                    params = params.set(key, data[key]);
                });
        }
        return params;
    }

    private headers (data: Object): HttpHeaders {
        let headers = new HttpHeaders();
        if (data) {
            Object.keys(data)
                .forEach((key) => {
                    headers = headers.set(key, data[key]);
                });
            return headers;
        }
    }

    private form (data: object): FormData {
        const form = new FormData();
        if (data) {
            Object.keys(data)
                .forEach((key) => form.append(key, data[key]));
        }
        return form;
    }

    private encode (data: any): string {
        const params = new URLSearchParams();
        if (data) {
            Object.keys(data)
                .forEach((key) => params.set(key, data[key]));
        }
        return params.toString();
    }

    private data (resource: Resource): any {
        if (resource.form) {
            return this.form(resource.form);
        }
        return resource.encode ? this.encode(resource.data) : resource.data;
    }

    private options (resource: Resource): object {
        const options = new Resource();

        if (resource.headers) {
            options.headers = this.headers(resource.headers);
        }
        if (resource.params) {
            options.params = this.params(resource.params);
        }
        if (resource.responseType) {
            options.responseType = resource.responseType;
        }
        if (resource.observe) {
            options.observe = resource.observe;
        }

        return options;
    }

    private _get<T> (resource: Resource): Observable<T> {
        return this.http.get<T>(this.url(resource), this.options(resource));
    }

    private _post<T> (resource: Resource): Observable<T> {
        return this.http.post<T>(this.url(resource), this.data(resource), this.options(resource));
    }

    private _delete<T> (resource: Resource): Observable<T> {
        return this.http.delete<T>(this.url(resource), this.options(resource));
    }

    private _put<T> (resource: Resource): Observable<T> {
        return this.http.put<T>(this.url(resource), this.data(resource), this.options(resource));
    }

    protected request<T> (resource: Resource | string): Observable<T> {
        if (typeof resource === 'string') {
            return this.http.get<T>(resource);
        } else {
            switch (resource.method || Method.GET) {
            case Method.POST:
                return this._post(resource);
            case Method.PUT:
                return this._put(resource);
            case Method.DELETE:
                return this._delete(resource);
            default:
                return this._get(resource);
            }
        }
    }
}
