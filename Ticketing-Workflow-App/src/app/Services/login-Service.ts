import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router'
import { retry, catchError } from 'rxjs/operators';
import { UserInfo } from '../Models/Models';
@Injectable({
    providedIn: 'root',
})

export class LoginService {

    apiUrl = 'http://localhost:21631/api/TicketingManagement';

    public isAuthenticated = new BehaviorSubject<boolean>(false);
    constructor(private httpClient: HttpClient, private router: Router) { }

    httpHeader = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }


    login(username: string, password: string): Observable<UserInfo> {
        let user = {
            username: username,
            password: password
        }
        return this.httpClient.post<UserInfo>(this.apiUrl + '/login', JSON.stringify(user), this.httpHeader)
            .pipe(
                retry(1),
                catchError(this.httpError)
            )
    }

    httpError(error: any) {
        let msg = '';
        if (error.error instanceof ErrorEvent) {
            // client side error
            msg = error.error.message;
        } else {
            // server side error
            msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(msg);
        return throwError(msg);
    }

}