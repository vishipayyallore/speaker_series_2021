import { Component, OnInit } from '@angular/core';

import { ProfessorDtoApi } from 'src/app/interfaces/professor-dto';
import { ProfessorsApiserviceService } from 'src/app/services/professors-apiservice.service';

@Component({
  selector: 'app-employees-cards',
  templateUrl: './employees-cards.component.html',
  styleUrls: ['./employees-cards.component.css']
})
export class EmployeesCardsComponent implements OnInit {

  employeesList: ProfessorDtoApi[] = [];
  ratingStars = 5;

  constructor(private professorsApiserviceService: ProfessorsApiserviceService) {
  }

  ngOnInit(): void {
    this.loadAllProfessors();
  }

  onRatingClicked(currentRating: number): void {
    console.log(`From Parent :: Current Selected Rating: ${currentRating}`);
  }
  
  loadAllProfessors() {
    this.professorsApiserviceService.GetAllProfessors()
      .subscribe((data: ProfessorDtoApi[]) => {
        this.employeesList = data;
        console.log(this.employeesList);
      });
  }

}
