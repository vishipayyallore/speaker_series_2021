import { Component } from "@angular/core";

import { IProfessor } from "../interfaces/IProfessor";

@Component({
  selector: 'app-professorv2',
  templateUrl: './professorv2.component.html',
  styleUrls: ['./professorv2.component.css']
})
export class ProfessorV2Component {

  professor: IProfessor;

  constructor() {
    this.professor = {
      professorId: 2,
      name: 'Mathew',
      dateOfJoin: new Date(),
      salary: 1234.56,
      isPhd: true
    };

  }

}