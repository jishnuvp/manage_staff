import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { StaffsComponent } from './staffs/staffs.component';

const routes: Routes = [
  { path: 'staffs', component: StaffsComponent },
  { path: '', redirectTo: '/staffs', pathMatch: 'full' }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
