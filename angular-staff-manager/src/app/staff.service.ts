import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { Staff } from './staff';

@Injectable({
  providedIn: 'root'
})
export class StaffService {


  private url = 'https://localhost:44305/staff/';

  constructor(private http: HttpClient) { }

  getStaffs(type: string): Observable<Staff> {
    return this.http.get<Staff>(this.url + `?type=${type}`);
  }

  getStaff(id: number): Observable<Staff> {
    return this.http.get<Staff>(this.url + `${id}`);
  }

}
