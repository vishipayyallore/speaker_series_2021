import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'College Web App';

  // We need this method if we are using <app-rating></app-rating> component
  onRatingClicked(currentRating: number): void {
    console.log(`From Parent :: Current Selected Rating: ${currentRating}`);
  }

}
