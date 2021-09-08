import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'sv-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    console.log('FooterComponent::ngOnInit');
  }

  getCurrentYear() {
    return (new Date()).getFullYear();
  }

}
