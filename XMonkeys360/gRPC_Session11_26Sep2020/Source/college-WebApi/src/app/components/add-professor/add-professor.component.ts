import { Component, OnInit, NgZone } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

import { AddProfessorDto } from '../../interfaces/professor.Dto';
import { ProfessorsService } from '../../services/professors.service';

@Component({
  selector: 'app-add-professor',
  templateUrl: './add-professor.component.html',
  styleUrls: ['./add-professor.component.css']
})
export class AddProfessorComponent implements OnInit {

  professor: AddProfessorDto;
  professorForm: FormGroup;

  constructor(private route: ActivatedRoute, private professorsService: ProfessorsService,
    private ngZone: NgZone, private router: Router, private formBuilder: FormBuilder) {

    this.professorForm = this.formBuilder.group({
      name: '',
      doj: '',
      teaches: '',
      salary: 0.0,
      isPhd: false
    });
  }

  ngOnInit(): void {
  }

  /* Add Professor */
  onProfessorAdd(professorData: AddProfessorDto): void {
    console.warn(`Professor Add Request received`);

    this.professorsService.AddProfessor(professorData).subscribe(res => {
      console.log('Professor Added!')
      this.ngZone.run(() => this.router.navigateByUrl('/professors'))
    });
  }


}
