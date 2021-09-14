import { Component } from '@angular/core';

@Component({
  selector: 'sv-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ng12-products';
  notificationsCount = 5;
}
