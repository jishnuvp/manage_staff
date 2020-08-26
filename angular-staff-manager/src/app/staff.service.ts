import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageService } from './message.service';

import { Staff } from './staff';

@Injectable({
  providedIn: 'root'
})
export class StaffService {

  staff: Staff;

  private url = 'https://localhost:44305/staff/';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  private log(message: string) {
    this.messageService.add(`HeroService : ${message}`);
  }

  getStaffs(type: string): Observable<Staff> {
    return this.http.get<Staff>(this.url + `?type=${type}`)
      .pipe(
        tap(_ => this.log('fetched heroes')),
        catchError(this.handleError<Staff>('getHeroes'))
      );
  }

  getStaff(id: number): Observable<Staff> {
    return this.http.get<Staff>(this.url + `${id}`)
      .pipe(
        tap(_ => this.log(`fetched hero id=${id}`)),
        catchError(this.handleError<Staff>(`getStaff id=${id}`))
      );
  }


  /** PUT: update the staff on the server */
  updateStaff(staff: Staff): Observable<any> {
    return this.http.put(this.url + `${staff.Id}`, JSON.stringify(staff), this.httpOptions).pipe(
      tap(_ => this.log(`updated hero id=${staff.Id}`)),
      catchError(this.handleError<any>('updateStaff'))
    );
  }

  // addHero(staff: Staff): Observable<Staff> {
  //   return this.http.post<Staff>(this.url, staff, httpOptions)
  //     .pipe(
  //       catchError(this.handleError('addHero', staff))
  //     );
  // }



  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead



      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
