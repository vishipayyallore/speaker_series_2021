import { Component, OnInit } from '@angular/core';

import { IProfessor } from 'src/app/interfaces/iprofessor';

@Component({
  selector: 'app-professors-list',
  templateUrl: './professors-list.component.html',
  styleUrls: ['./professors-list.component.css']
})
export class ProfessorsListComponent implements OnInit {

  professorsList: IProfessor[];
  imageWidth = 40;
  imageMargin = 1;

  constructor() {
    this.professorsList = [
      {
        professorId: 1,
        pictureUrl: 'assets/images/Emp1.png',
        name: 'Shiva',
        dateOfJoin: new Date(),
        salary: 4567.5678,
        isPhd: true,
        teaches: 'C#'
      },
      {
        professorId: 2,
        pictureUrl: 'assets/images/Emp2.png',
        name: 'Mathews',
        dateOfJoin: new Date(),
        salary: 1111.5678,
        isPhd: true,
        teaches: 'Java'
      },
      {
        professorId: 3,
        pictureUrl: 'assets/images/Emp3.png',
        name: 'Hafeez',
        dateOfJoin: new Date(),
        salary: 2222.5678,
        isPhd: false,
        teaches: 'Node JS'
      }
    ];
  }

  ngOnInit(): void {
  }

}
