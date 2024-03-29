import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { IEmployee } from 'src/app/interfaces/iemployee';
import { EmployessService } from 'src/app/services/employess.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  employeesList: IEmployee[];
  ratingStars = 5;
  errorMessage: string;

  constructor(private employessService: EmployessService) { }

  ngOnInit(): void {

    // setTimeout(() => {
    //   this.employeesList = this.getEmployeesList();
    // }, 1000);

    this.employessService.getAllEmployees()
      .subscribe({
        next: (response: IEmployee[]) => {
          this.employeesList = response;
        },
        error: (errorObject: HttpErrorResponse) => {
          this.employeesList = [];
          this.errorMessage = JSON.stringify(errorObject);
          console.error(`Error Occurred at EmployeesListComponent::ngOnInit() === ${JSON.stringify(errorObject)}`);
        },
        complete: () => {
        }
      });

  }

  onRatingClicked(currentRating: number): void {
    console.log(`From Parent :: Current Selected Rating: ${currentRating}`);
  }

  getEmployeesList(): IEmployee[] {
    return [
      // {
      //   id: 'A101',
      //   fullName: 'Mithun Nair',
      //   pictureUrl: 'assets/images/Emp1.png',
      //   department: 'Software',
      //   age: 25,
      //   address: {
      //     street: 'Safilguda',
      //     city: 'Hyderabad',
      //     state: 'Telangana'
      //   },
      //   rating: 4.2
      // },
      // {
      //   id: 'A102',
      //   fullName: 'George Reddy',
      //   pictureUrl: 'assets/images/Emp2.png',
      //   department: 'Hardward',
      //   age: 21,
      //   address: {
      //     street: 'Safilguda',
      //     city: 'Hyderabad',
      //     state: 'Telangana'
      //   },
      //   rating: 4.6
      // },
      // {
      //   id: 'A103',
      //   fullName: 'Manpreet Singh',
      //   pictureUrl: 'assets/images/Emp3.png',
      //   department: 'Software',
      //   age: 23,
      //   address: {
      //     street: 'Safilguda',
      //     city: 'Hyderabad',
      //     state: 'Telangana'
      //   },
      //   rating: 3.4
      // }
    ];
  }

}
