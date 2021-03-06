import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
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
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    observe: 'response' as 'body'
  };


  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  // private log(message: string) {
  //   this.messageService.showToasterMessage(`StaffService : ${message}`, );
  // }

  /** GET: get all staffs by type from the server */
  getStaffs(type: string): Observable<any> {
    return this.http.get<any>(this.url + `?type=${type}`)
      .pipe(
        //tap(_ => this.log('fetched staff')),
        catchError(this.handleError<any>('getStaffs'))
      );
  }

  /** GET: get staff by ID from the server */
  getStaff(id: number): Observable<Staff> {
    return this.http.get<Staff>(this.url + `${id}`)
      .pipe(
        //tap(_ => this.log(`fetched staff id=${id}`)),
        catchError(this.handleError<Staff>(`getStaff id=${id}`))
      );
  }

  /** POST: add the staff on the server */
  addStaff(staff: Staff): Observable<any> {
    staff.DateOfJoin = new Date();

    return this.http.post(this.url, JSON.stringify(staff), this.httpOptions)
      .pipe(
        catchError(this.handleError('addStaff', staff))
      );
  }


  /** PUT: update the staff on the server */
  updateStaff(staff: Staff): Observable<any> {
    return this.http.put<Staff>(this.url + `${staff.Id}`, JSON.stringify(staff), this.httpOptions)
      .pipe(
        catchError(this.handleError<Staff>('updateStaff'))
      );
  }

  /** DELETE: delete staff on the server */
  deleteStaffs(deleteList: any): Observable<any> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: JSON.stringify(deleteList),
      observe: 'response' as 'body'
    };
    return this.http.delete<Staff>(this.url, options)
      .pipe(
        catchError(this.handleError<Staff>('deleteStaff'))
      );
  }

  deleteStaffById(id: number): Observable<any> {
    const options = {
      observe: 'response' as 'body'
    };
    return this.http.delete<any>(this.url + `${id}`, options)
      .pipe(
        catchError(this.handleError<any>('deleteStaff'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead



      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
