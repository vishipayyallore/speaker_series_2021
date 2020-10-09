import { Component, OnInit, NgZone } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

import { ProfessorDto } from '../../interfaces/professor.Dto';
import { ProfessorsService } from '../../services/professors.service';

@Component({
    selector: 'app-edit-professor',
    templateUrl: './edit-professor.component.html',
    styleUrls: ['./edit-professor.component.css']
})
export class EditProfessorComponent implements OnInit {

    professor: ProfessorDto;
    professorForm: FormGroup;

    constructor(private route: ActivatedRoute, private professorsService: ProfessorsService,
        private ngZone: NgZone, private router: Router, private formBuilder: FormBuilder) {

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

    /* For Modify */
    onProfessorEdit(id: number, professorData: ProfessorDto): void {
        console.warn(`Professor Edit Request for Id: ${id}`);

        this.professorsService.EditProfessorById(id, professorData).subscribe(res => {
            console.log('Professor Modified!')
            this.ngZone.run(() => this.router.navigateByUrl('/professors'))
        });
    }

}
