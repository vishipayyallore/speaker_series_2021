import { Component, OnInit } from '@angular/core';
import { IEmployee } from 'src/app/interfaces/iemployee';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  employeesList: IEmployee[];
  
  constructor() { }

  ngOnInit(): void {
    this.employeesList = [
      {
        id: 'A101',
        fullName: 'Mithun Nair',
        pictureUrl: 'assets/images/Emp1.png',
        department: 'Software',
        age: 25,
        address: {
          street: 'Safilguda',
          city: 'Hyderabad',
          state: 'Telangana'
        },
        rating: 4.2
      },
      {
        id: 'A102',
        fullName: 'George Reddy',
        pictureUrl: 'assets/images/Emp2.png',
        department: 'Hardward',
        age: 21,
        address: {
          street: 'Safilguda',
          city: 'Hyderabad',
          state: 'Telangana'
        },
        rating: 4.7
      },
      {
        id: 'A103',
        fullName: 'Manpreet Singh',
        pictureUrl: 'assets/images/Emp3.png',
        department: 'Software',
        age: 23,
        address: {
          street: 'Safilguda',
          city: 'Hyderabad',
          state: 'Telangana'
        },
        rating: 3.4
      }
    ];
  }

}
