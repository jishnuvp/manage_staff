import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {


  showToasterMessage(error, bgColor): void {
    let x: HTMLElement = document.querySelector("#validate-alert");
    x.setAttribute("style", `background-color:${bgColor};`);
    x.innerHTML = error;
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
  }
}
