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
  selectedType: string;
  userAction: string;

  getStaffs($type = 'Teaching'): void {
    this.staffService.getStaffs($type)
      .subscribe(staffs => this.staffs = staffs.StaffList);
  }

  modelActions(): void {
    let modal: HTMLElement = document.querySelector("#staff-modal");
    let close: HTMLElement = document.querySelector("#staff-modal .close");
    modal.style.display = "block";
    close.onclick = function () {
      modal.style.display = "none";
    }
    window.onclick = function (event) {
      if (event.target == modal) {
        modal.style.display = "none";
      }
    }

    document.querySelector('#staff-modal .teaching-fields').classList.add('d-none');  //for hiding all custom fields
    document.querySelector('#staff-modal .administrative-fields').classList.add('d-none');
    document.querySelector('#staff-modal .support-fields').classList.add('d-none');
  }

  validate(isAdd): boolean {
    let code = (<HTMLInputElement>document.querySelector('#staff-modal input[name="EmpCode"]')).value;
    let name = (<HTMLInputElement>document.querySelector('#staff-modal input[name="Name"]')).value;
    let number = (<HTMLInputElement>document.querySelector('#staff-modal input[name="ContactNumber"]')).value;
    let subject = (<HTMLInputElement>document.querySelector('#staff-modal input[name="Subject"]')).value;
    let role = (<HTMLInputElement>document.querySelector('#staff-modal input[name="Role"]')).value;
    let department = (<HTMLInputElement>document.querySelector('#staff-modal input[name="Department"]')).value;
    var type;
    if (isAdd) {
      type = (<HTMLInputElement>document.querySelector('#staff-modal select[name="StaffType"]')).value;
    } else {
      type = (<HTMLInputElement>document.querySelector('#staff-modal input[name="StaffType"]')).value;
    }
    if (code == '' || name == '' || name.length > 25 || number == '' || number.length > 15 || !(/^[a-zA-Z][a-zA-Z_ ]*[a-zA-Z_]+$/.test(name)) || !(/^[0-9]+$/.test(number))) {
      return false;
    }
    if (type == 'Teaching' && subject == '' || type == 'Teaching' && !(/^[a-zA-Z]+$/.test(subject)) || type == 'Teaching' && subject.length > 15) {
      return false;
    } else if (type == 'Administrative' && role == '' || type == 'Administrative' && !(/^[a-zA-Z]+$/.test(role)) || type == 'Administrative' && role.length > 15) {
      return false;
    } else if (type == 'Support' && department == '' || type == 'Support' && !(/^[a-zA-Z]+$/.test(department)) || type == 'Support' && department.length > 15) {
      return false;
    }
    return true;
  }

  renderAddPopup() {
    this.userAction = 'add';
    this.modelActions();
  }

}
