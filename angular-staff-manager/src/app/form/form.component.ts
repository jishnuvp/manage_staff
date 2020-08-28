import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

import { Staff } from '../staff';
import { StaffService } from '../staff.service';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Input() staff: Staff;
  @Input() isAdd: boolean;
  @Input() isEdit: boolean;
  @Input() isReadOnly: boolean;

  @Output() getStaffs = new EventEmitter();

  constructor(private staffService: StaffService, private messageService: MessageService) { }

  ngOnInit(): void {
  }

  updateStaff(): void {
    let flag: boolean;
    flag = this.validate();
    if (flag) {
      this.staffService.updateStaff(this.staff)
        .subscribe(
          (response) => {
            if (response.status == 200) {
              let modal: HTMLElement = document.querySelector("#staff-modal");
              modal.style.display = "none";
              this.messageService.showToasterMessage('Staff updated succesfully', '#00800099');
            } else {
              this.messageService.showToasterMessage('Something went wrong', '#ea2121');
            }
          });
    } else {
      this.messageService.showToasterMessage('Please submit valid data only', '#ea2121');
    }
  }

  addStaff(): void {
    let flag: boolean;
    flag = this.validate();
    if (flag) {
      this.staffService.addStaff(this.staff)
        .subscribe(
          (response) => {
            if (response.status == 201) {
              let modal: HTMLElement = document.querySelector("#staff-modal");
              this.getStaffs.emit();
              modal.style.display = "none";
              this.messageService.showToasterMessage('Staff updated succesfully', '#00800099');

            } else {
              this.messageService.showToasterMessage('EmpCode already exists, Try with another EmpCode.', '#ea2121');
            }
          }
        );
    } else {
      this.messageService.showToasterMessage('Please submit valid data only', '#ea2121');
    }
  }

  validate(): boolean {

    if (this.staff.EmpCode == '' || this.staff.Name == '' || this.staff.Name.length > 25 || this.staff.ContactNumber == '' || this.staff.ContactNumber.length > 15 || !(/^[a-zA-Z][a-zA-Z_ ]*[a-zA-Z_]+$/.test(this.staff.Name)) || !(/^[0-9]+$/.test(this.staff.ContactNumber))) {
      return false;
    }
    if (this.staff.StaffType == '' || this.staff.StaffType == 'Teaching' && this.staff.Subject == '' || this.staff.StaffType == 'Teaching' && !(/^[a-zA-Z]+$/.test(this.staff.Subject)) || this.staff.StaffType == 'Teaching' && this.staff.Subject.length > 15) {
      return false;
    } else if (this.staff.StaffType == 'Administrative' && this.staff.Role == '' || this.staff.StaffType == 'Administrative' && !(/^[a-zA-Z]+$/.test(this.staff.Role)) || this.staff.StaffType == 'Administrative' && this.staff.Role.length > 15) {
      return false;
    } else if (this.staff.StaffType == 'Support' && this.staff.Department == '' || this.staff.StaffType == 'Support' && !(/^[a-zA-Z]+$/.test(this.staff.Department)) || this.staff.StaffType == 'Support' && this.staff.Department.length > 15) {
      return false;
    }
    return true;
  }



}
