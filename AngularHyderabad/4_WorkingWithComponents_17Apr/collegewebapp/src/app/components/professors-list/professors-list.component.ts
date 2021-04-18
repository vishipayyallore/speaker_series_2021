import { Component, OnInit } from '@angular/core';
import { IProfessor } from 'src/app/interfaces/IProfessor';

@Component({
  selector: 'app-professors-list',
  templateUrl: './professors-list.component.html',
  styleUrls: ['./professors-list.component.css']
})
export class ProfessorsListComponent implements OnInit {

  professorsList: IProfessor[];

  constructor() {
    this.professorsList = [
      {
        professorId: 1,
        name: 'Shiva',
        dateOfJoin: new Date(),
        salary: 4567.5678,
        isPhd: true,
        teaches: 'C#'
      },
      {
        professorId: 2,
        name: 'Mathews',
        dateOfJoin: new Date(),
        salary: 1111.5678,
        isPhd: true,
        teaches: 'Java'
      },
      {
        professorId: 3,
        name: 'Hafeez',
        dateOfJoin: new Date(),
        salary: 2222.5678,
        isPhd: true,
        teaches: 'Node JS'
      }
    ];
  }

  ngOnInit(): void {
  }

}
