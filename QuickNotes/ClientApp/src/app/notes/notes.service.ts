import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Note } from '../notes/note';
import { Response } from '../response';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  private apiUrl = "https://qnote.azurewebsites.net/api";
  //private apiUrl = "https://localhost:7192/api";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient) { }

  getNotes(userId: number): Observable<Response> {
    return this.httpClient.get<Response>(this.apiUrl + "/note/" + userId)
      .pipe(catchError(this.errorHandler));
  }

  createNote(note: Note): Observable<Response> {
    return this.httpClient.post<Response>(this.apiUrl + "/note", note, this.httpOptions)
      .pipe(catchError(this.errorHandler));
  }

  deleteNote(noteId: number): Observable<Response> {
    return this.httpClient.delete<Response>(this.apiUrl + "/note/" + noteId)
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
