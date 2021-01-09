import { Component, OnInit } from '@angular/core';

import { IProfessor } from 'src/interfaces/IProfessor';

@Component({
  selector: 'app-professorv3',
  templateUrl: './professorv3.component.html',
  styleUrls: ['./professorv3.component.css']
})
export class Professorv3Component implements OnInit {

  professor: IProfessor;

  constructor() {
    this.professor = {
      professorId: 3,
      name: 'Hafeez',
      dateOfJoin: new Date(),
      salary: 1234.56,
      isPhd: true
    };
  }

  ngOnInit(): void {
  }

}
