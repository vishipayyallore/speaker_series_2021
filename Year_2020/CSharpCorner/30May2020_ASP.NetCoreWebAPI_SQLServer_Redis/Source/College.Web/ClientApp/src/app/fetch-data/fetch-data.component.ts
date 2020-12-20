import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const baseApiUrl = 'https://localhost:44312/api/';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public professors: Professor[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(`${baseApiUrl}weatherforecast`).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

    // Retrieving Professosrs
    http.get<Professor[]>(`${baseApiUrl}professors`).subscribe(result => {
      this.professors = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}


interface Professor {
  professorId: string;
  name: number;
  doj: string;
  teaches: string;
  salary: number;
  isPhd: boolean;
}
