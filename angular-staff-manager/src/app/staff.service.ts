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
    this.messageService.add(`StaffService : ${message}`);
  }

  getStaffs(type: string): Observable<Staff> {
    return this.http.get<Staff>(this.url + `?type=${type}`)
      .pipe(
        tap(_ => this.log('fetched staff')),
        catchError(this.handleError<Staff>('getStaffs'))
      );
  }

  getStaff(id: number): Observable<Staff> {
    return this.http.get<Staff>(this.url + `${id}`)
      .pipe(
        tap(_ => this.log(`fetched staff id=${id}`)),
        catchError(this.handleError<Staff>(`getStaff id=${id}`))
      );
  }

  addStaff(staff: Staff): Observable<Staff> {
    staff.DateOfJoin = new Date();

    return this.http.post<Staff>(this.url, JSON.stringify(staff), this.httpOptions)
      .pipe(
        catchError(this.handleError('addStaff', staff))
      );
  }


  /** PUT: update the staff on the server */
  updateStaff(staff: Staff): Observable<any> {
    return this.http.put<any>(this.url + `${staff.Id}`, JSON.stringify(staff), this.httpOptions)
      .pipe(
        // map(res => {
        //   debugger;
        //   console.log(res.status);
        //   return res;
        // }),
        catchError(this.handleError<Staff>('updateStaff'))
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
