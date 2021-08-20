import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'sv-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    console.log('DashboardComponent::ngOnInit');
  }

}
