import { Component, OnInit } from '@angular/core';

import { IProfessor } from '../interfaces/IProfessor';

@Component({
  selector: 'app-professorv2',
  templateUrl: './professorv2.component.html',
  styleUrls: ['./professorv2.component.css']
})
export class Professorv2Component implements OnInit {

  professor: IProfessor;

  constructor() {
    this.professor = {
      professorId: 1,
      name: 'Shiva',
      dateOfJoin: new Date(),
      salary: 1234.56,
      isPhd: true
    };
  }

  ngOnInit(): void {
  }

}
