import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-edit-professor',
  templateUrl: './edit-professor.component.html',
  styleUrls: ['./edit-professor.component.css']
})
export class EditProfessorComponent implements OnInit {

  professorId: number;

  constructor(private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {

    // Method 1 and 2
    // this.activatedRoute.params.subscribe(params => {
    //   // this.professorId = params.professorId; // Method 1
    //   this.professorId = params['professorId']; // Method 2
    // });

    // Method 3
    this.activatedRoute.paramMap.subscribe(params => {
      this.professorId = +params.get('professorId');
    });

  }

}
