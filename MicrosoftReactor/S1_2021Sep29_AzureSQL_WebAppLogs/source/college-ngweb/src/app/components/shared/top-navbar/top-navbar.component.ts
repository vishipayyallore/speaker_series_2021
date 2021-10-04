import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'sv-top-navbar',
  templateUrl: './top-navbar.component.html',
  styleUrls: ['./top-navbar.component.scss']
})
export class TopNavbarComponent implements OnInit {

  notificationsCount = 9;
  
  constructor() { }

  ngOnInit(): void {
  }

}
