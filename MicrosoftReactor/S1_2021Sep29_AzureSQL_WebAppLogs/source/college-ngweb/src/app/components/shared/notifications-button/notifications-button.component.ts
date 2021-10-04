import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'sv-notifications-button',
  templateUrl: './notifications-button.component.html',
  styleUrls: ['./notifications-button.component.scss']
})
export class NotificationsButtonComponent implements OnInit {

  @Input()
  count = 0;

  constructor() { }

  ngOnInit(): void {
  }

}
