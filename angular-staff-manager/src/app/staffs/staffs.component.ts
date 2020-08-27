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
  selectedType: string = 'Teaching';
  isAdd: boolean;
  isEdit: boolean;
  isReadOnly: boolean;

  getStaffs(): void {
    this.staffService.getStaffs(this.selectedType)
      .subscribe(staffs => this.staffs = staffs.StaffList);
  }

  updateStaff(): void {
    let flag: boolean;
    flag = this.validate();
    if (flag) {
      this.staffService.updateStaff(this.selectedStaff)
        .subscribe();
      let modal: HTMLElement = document.querySelector("#staff-modal");
      modal.style.display = "none";
      this.showToasterMessage('Staff updated succesfully', '#00800099');
    } else {
      this.showToasterMessage('Please submit valid data only', '#ea2121');
    }
  }

  addStaff(): void {
    let flag: boolean;
    flag = this.validate();
    if (flag) {
      this.staffService.addStaff(this.selectedStaff)
        .subscribe();
      let modal: HTMLElement = document.querySelector("#staff-modal");
      modal.style.display = "none";
      this.showToasterMessage('Staff updated succesfully', '#00800099');
    } else {
      this.showToasterMessage('Please submit valid data only', '#ea2121');
    }
  }

  renderEditPopup(staff: Staff): void {
    this.isAdd = false;
    this.isEdit = true;
    this.isReadOnly = true;
    this.selectedStaff = staff;
    this.selectedType = staff.StaffType;
    this.modelActions();
  }

  renderAddPopup(): void {
    this.isAdd = true;
    this.isReadOnly = false;
    this.isEdit = false;
    let staff = new Staff();
    this.selectedStaff = staff;
    this.selectedStaff.StaffType = this.selectedType;
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

  validate(): boolean {

    if (this.selectedStaff.EmpCode == '' || this.selectedStaff.Name == '' || this.selectedStaff.Name.length > 25 || this.selectedStaff.ContactNumber == '' || this.selectedStaff.ContactNumber.length > 15 || !(/^[a-zA-Z][a-zA-Z_ ]*[a-zA-Z_]+$/.test(this.selectedStaff.Name)) || !(/^[0-9]+$/.test(this.selectedStaff.ContactNumber))) {
      return false;
    }
    if (this.selectedStaff.StaffType == '' || this.selectedStaff.StaffType == 'Teaching' && this.selectedStaff.Subject == '' || this.selectedStaff.StaffType == 'Teaching' && !(/^[a-zA-Z]+$/.test(this.selectedStaff.Subject)) || this.selectedStaff.StaffType == 'Teaching' && this.selectedStaff.Subject.length > 15) {
      return false;
    } else if (this.selectedStaff.StaffType == 'Administrative' && this.selectedStaff.Role == '' || this.selectedStaff.StaffType == 'Administrative' && !(/^[a-zA-Z]+$/.test(this.selectedStaff.Role)) || this.selectedStaff.StaffType == 'Administrative' && this.selectedStaff.Role.length > 15) {
      return false;
    } else if (this.selectedStaff.StaffType == 'Support' && this.selectedStaff.Department == '' || this.selectedStaff.StaffType == 'Support' && !(/^[a-zA-Z]+$/.test(this.selectedStaff.Department)) || this.selectedStaff.StaffType == 'Support' && this.selectedStaff.Department.length > 15) {
      return false;
    }
    return true;
  }





  showToasterMessage(error, bgColor): void {
    let x: HTMLElement = document.querySelector("#validate-alert");
    x.setAttribute("style", `background-color:${bgColor};`);
    x.innerHTML = error;
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
  }

}
