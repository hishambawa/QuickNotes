import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Response } from '../response';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = "https://qnote.azurewebsites.net/api";
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json'
    })
  };
  constructor(private httpClient: HttpClient) { }

  login(user: User): Observable<Response> {
    return this.httpClient.post<Response>(this.apiUrl + "/user", user, this.httpOptions)
      .pipe(catchError(this.errorHandler));
  }

  errorHandler(error: any) {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
