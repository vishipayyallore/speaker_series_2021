import { Component, OnInit, NgZone } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { ProfessorDto } from '../../interfaces/professor.Dto';
import { ProfessorsService } from '../../services/professors.service';

@Component({
  selector: 'app-remove-professor',
  templateUrl: './remove-professor.component.html',
  styleUrls: ['./remove-professor.component.css']
})
export class RemoveProfessorComponent implements OnInit {

  professor: ProfessorDto;
  professorForm: FormGroup;

  constructor(private route: ActivatedRoute, private professorsService: ProfessorsService,
    private ngZone: NgZone, private router: Router, private formBuilder: FormBuilder, private toastr: ToastrService) {

    this.professorForm = this.formBuilder.group({
      professorId: '',
      name: '',
      doj: '',
      teaches: '',
      salary: 0.0,
      isPhd: false
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {

      this.professorsService.GetProfessorById(params.get('professorId'))
        .subscribe((professor: ProfessorDto) => {

          this.professor = professor;
          console.log(`${this.professor.name}`);
        });
    });
  }

  onProfessorRemove(id: number): void {

    console.warn(`Product Delete Request for Id: ${id}`);

    this.professorsService.RemoveProfessorById(id).subscribe(res => {

        console.log('Professor Deleted!')
        this.toastr.success('Professor Deleted.', 'College');
        this.ngZone.run(() => this.router.navigateByUrl('/professors'))
    });
}

}
