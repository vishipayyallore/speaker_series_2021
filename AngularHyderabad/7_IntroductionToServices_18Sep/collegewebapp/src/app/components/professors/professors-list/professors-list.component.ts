import { Component, OnInit } from '@angular/core';
import { IProfessor } from 'src/app/interfaces/IProfessor';

@Component({
  selector: 'app-professors-list',
  templateUrl: './professors-list.component.html',
  styleUrls: ['./professors-list.component.css']
})
export class ProfessorsListComponent implements OnInit {

  professorsList: IProfessor[];
  imageWidth = 50;
  imageMargin = 1;

  constructor() {
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.professorsList = this.getProfessorsList();
    }, 1000);
  }

  getProfessorsList(): IProfessor[] {
    return [
      {
        professorId: 1,
        name: 'Shiva',
        pictureUrl: 'assets/images/Emp1.png',
        dateOfJoin: new Date(),
        salary: 4567.5678,
        isPhd: true,
        teaches: 'C#'
      },
      {
        professorId: 2,
        name: 'Mathews',
        pictureUrl: 'assets/images/Emp2.png',
        dateOfJoin: new Date(),
        salary: 1111.5678,
        isPhd: true,
        teaches: 'Java'
      },
      {
        professorId: 3,
        name: 'Hafeez',
        pictureUrl: 'assets/images/Emp3.png',
        dateOfJoin: new Date(),
        salary: 2222.5678,
        isPhd: true,
        teaches: 'Node JS'
      }
    ];
  }

}
