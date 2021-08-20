import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'sv-contactus',
  templateUrl: './contactus.component.html',
  styleUrls: ['./contactus.component.css']
})
export class ContactusComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    console.log('ContactusComponent::ngOnInit');
  }

}
