import { Component, OnInit } from '@angular/core';

import { ProfessorsService } from '../../services/professors.service';
import { ProfessorDto, ProfessorsFromGrpc } from '../../interfaces/professor.Dto';

@Component({
  selector: 'app-professors-list',
  templateUrl: './professors-list.component.html',
  styleUrls: ['./professors-list.component.css'],
})
export class ProfessorsListComponent implements OnInit {
  professorsList: ProfessorDto[] = [];

  constructor(private professorsService: ProfessorsService) { }

  ngOnInit(): void {
    this.loadAllProfessors();
  }

  loadAllProfessors() {

    this.professorsService
      .GetAllProfessorsFromgRPC()
      .then((results: ProfessorsFromGrpc) => {

        console.log(`Inside UI Results: ${results}`);
        this.professorsList = results.professorsList;
      });

    /*
    this.professorsService.GetAllProfessors()
    .subscribe((data: ProfessorDto[]) => {
      this.professorsList = data;
      console.log(this.professorsList);
    });
    */

  }
}
