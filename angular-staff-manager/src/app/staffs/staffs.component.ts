import { Component, OnInit } from '@angular/core';
import { Staff } from '../staff';
import { StaffService } from '../staff.service';

@Component({
  selector: 'app-staffs',
  templateUrl: './staffs.component.html',
  styleUrls: ['./staffs.component.css']
})
export class StaffsComponent implements OnInit {

  constructor(private staffService: StaffService) { }

  ngOnInit(): void {
    this.getStaffs();
  }

  staffs: Staff;

  getStaffs($type = 'Teaching'): void {
    this.staffService.getStaffs($type)
      .subscribe(staffs => this.staffs = staffs.StaffList);
  }

}
