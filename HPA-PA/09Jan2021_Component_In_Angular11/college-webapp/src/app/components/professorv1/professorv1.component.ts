import { Component, OnInit } from '@angular/core';

import { IProfessor } from '../../interfaces/IProfessor';

@Component({
  selector: 'app-professorv1',
  templateUrl: './professorv1.component.html',
  styleUrls: ['./professorv1.component.css']
})
export class Professorv1Component implements OnInit {

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
