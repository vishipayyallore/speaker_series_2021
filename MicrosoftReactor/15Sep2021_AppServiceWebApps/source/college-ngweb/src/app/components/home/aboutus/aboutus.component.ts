import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'sv-aboutus',
  templateUrl: './aboutus.component.html',
  styleUrls: ['./aboutus.component.css']
})
export class AboutusComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    console.log('AboutusComponent::ngOnInit');
  }

}
