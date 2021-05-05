import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Category, SubCategory, TicketRequest} from '../Models/Models';


@Injectable({
  providedIn: 'root',
})

export class TicketManagmenetService {

  apiUrl = 'https://localhost:44331/api/TicketingManagement';

  constructor(private httpClient: HttpClient) { }

  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }  

  getCategories(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(this.apiUrl + '/GetCategories')
    .pipe(
      retry(1),
      catchError(this.httpError)
    )
  }

  getSubCategories(): Observable<SubCategory[]> {
    return this.httpClient.get<SubCategory[]>(this.apiUrl + '/GetSubCategories')
    .pipe(
      retry(1),
      catchError(this.httpError)
    )
  }

  saveTicketMetaData(ticketMetaData: TicketRequest): Observable<boolean> {
    return this.httpClient.post<boolean>(this.apiUrl + '/SaveNewTicketRequest', JSON.stringify(ticketMetaData), this.httpHeader)
    .pipe(
      retry(1),
      catchError(this.httpError)
    )
  } 

/* getUser(id): Observable<User> {
    return this.httpClient.get<User>(this.apiUrl + '/users/' + id)
    .pipe(
      retry(1),
      catchError(this.httpError)
    )
  }  

  create(employee): Observable<User> {
    return this.httpClient.post<User>(this.apiUrl + '/users', JSON.stringify(employee), this.httpHeader)
    .pipe(
      retry(1),
      catchError(this.httpError)
    )
  }  */

  httpError(error: any) {
    let msg = '';
    if(error.error instanceof ErrorEvent) {
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