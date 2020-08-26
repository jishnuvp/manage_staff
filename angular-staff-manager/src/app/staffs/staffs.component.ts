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
  selectedStaff: Staff;
  selectedType: string;
  isAdd: boolean;
  isEdit: boolean;
  isReadOnly: boolean;

  getStaffs($type = 'Teaching'): void {
    this.staffService.getStaffs($type)
      .subscribe(staffs => this.staffs = staffs.StaffList);
  }

  updateStaff(): void {
    let flag: boolean;
    flag = this.validate(this.isAdd);
    if (flag) {
      this.staffService.updateStaff(this.selectedStaff)
        .subscribe();
    } else {
      this.showToasterMessage('Please submit valid data only', '#ea2121');
    }
  }

  renderEditPopup(staff: Staff): void {
    this.isAdd = false;
    this.isEdit = true;
    this.isReadOnly = true;

    // this.staffService.getStaff(selectedStaff.Id)
    //   .subscribe(selectedStaff => this.selectedStaff = selectedStaff.staff);

    this.selectedStaff = staff;


    this.selectedType = staff.StaffType;

    this.modelActions();

  }
  renderAddPopup(): void {
    this.isAdd = true;
    this.isReadOnly = false;
    this.isEdit = false;
    this.selectedStaff = null;
    this.selectedType = 'Teaching';
    this.modelActions();
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
  }

  validate(isAdd): boolean {
    let code = (<HTMLInputElement>document.querySelector('#staff-modal input[name="EmpCode"]')).value;
    let name = (<HTMLInputElement>document.querySelector('#staff-modal input[name="Name"]')).value;
    let number = (<HTMLInputElement>document.querySelector('#staff-modal input[name="ContactNumber"]')).value;
    var type, subject, role, department;
    if (isAdd) {
      type = (<HTMLInputElement>document.querySelector('#staff-modal select[name="StaffType"]')).value;
    } else {
      type = (<HTMLInputElement>document.querySelector('#staff-modal input[name="StaffType"]')).value;
    }
    if (type == 'Teaching')
      subject = (<HTMLInputElement>document.querySelector('#staff-modal input[name="Subject"]')).value;
    if (type == 'Administrative')
      role = (<HTMLInputElement>document.querySelector('#staff-modal input[name="Role"]')).value;
    if (type == 'Support')
      department = (<HTMLInputElement>document.querySelector('#staff-modal input[name="Department"]')).value;



    if (code == '' || name == '' || name.length > 25 || number == '' || number.length > 15 || !(/^[a-zA-Z][a-zA-Z_ ]*[a-zA-Z_]+$/.test(name)) || !(/^[0-9]+$/.test(number))) {
      return false;
    }
    if (type == '' || type == 'Teaching' && subject == '' || type == 'Teaching' && !(/^[a-zA-Z]+$/.test(subject)) || type == 'Teaching' && subject.length > 15) {
      return false;
    } else if (type == 'Administrative' && role == '' || type == 'Administrative' && !(/^[a-zA-Z]+$/.test(role)) || type == 'Administrative' && role.length > 15) {
      return false;
    } else if (type == 'Support' && department == '' || type == 'Support' && !(/^[a-zA-Z]+$/.test(department)) || type == 'Support' && department.length > 15) {
      return false;
    }
    return true;
  }





  addStaff(): void {
    let flag = this.validate(this.isAdd);
    if (flag) {
      let data;
      let code = (<HTMLInputElement>document.querySelector('#staff-modal input[name="EmpCode"]')).value;
      let name = (<HTMLInputElement>document.querySelector('#staff-modal input[name="Name"]')).value;
      let type = (<HTMLInputElement>document.querySelector('#staff-modal select[name="StaffType"]')).value;
      let number = (<HTMLInputElement>document.querySelector('#staff-modal input[name="ContactNumber"]')).value;
      let date = new Date().toISOString();

    }

  }

  showToasterMessage(error, bgColor): void {
    let x: HTMLElement = document.querySelector("#validate-alert");
    x.setAttribute("style", `background-color:${bgColor};`);
    x.innerHTML = error;
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
  }

}
