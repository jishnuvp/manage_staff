import { Component, OnInit } from '@angular/core';
import { Staff } from '../staff';
import { StaffService } from '../staff.service';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-staffs',
  templateUrl: './staffs.component.html',
  styleUrls: ['./staffs.component.css']
})
export class StaffsComponent implements OnInit {

  constructor(private staffService: StaffService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.getStaffs();
  }

  staffs: Staff[];
  selectedStaff: Staff;
  selectedType: string = 'Teaching';
  isAdd: boolean;
  isEdit: boolean;
  isReadOnly: boolean;
  deleteList: number[] = [];
  isCheckAll: boolean;

  getStaffs(): void {
    this.isCheckAll = false;
    this.staffService.getStaffs(this.selectedType)
      .subscribe(data => this.staffs = data?.StaffList);
  }

  deleteStaffs(): void {
    this.staffService.deleteStaffs(this.deleteList)
      .subscribe(
        (response) => {
          if (response.status == 200) {
            this.messageService.showToasterMessage('Deleted successfully', '#00800099');
            this.deleteList.length = 0;
            this.isCheckAll = false;
            this.getStaffs();
          } else {
            this.messageService.showToasterMessage('Something went wrong', '#ea2121');
          }
        }
      );
  }

  deleteStaff(id): void {
    this.staffService.deleteStaffById(id)
      .subscribe(
        (response) => {
          if (response.status == 200) {
            this.messageService.showToasterMessage('Deleted successfully', '#00800099');
            this.deleteList.length = 0;
            this.isCheckAll = false;
            this.getStaffs();
          } else {
            this.messageService.showToasterMessage('Something went wrong', '#ea2121');
          }
        }
      );
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

  generateDeleteList(id, event): void {
    if (event.target.checked) {
      this.deleteList.push(id);
    } else {
      this.deleteList = this.deleteList.filter(function (ele) {
        return ele != id;
      });
    }
  }
  generateDeleteListOnSelectAll(event): void {
    this.deleteList.length = 0;
    if (event.target.checked) {
      this.isCheckAll = true;
      for (let i = 0; i < this.staffs.length; i++) {
        this.deleteList.push(this.staffs[i].Id);
      }
    } else {
      this.isCheckAll = false;
    }
  }
}
