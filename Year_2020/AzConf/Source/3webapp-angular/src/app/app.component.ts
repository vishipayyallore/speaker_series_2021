import { Component } from '@angular/core';
import { AppInsightsService } from './services/app-insights.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'college-web';

  constructor(private appInsights: AppInsightsService) {
  }

}
