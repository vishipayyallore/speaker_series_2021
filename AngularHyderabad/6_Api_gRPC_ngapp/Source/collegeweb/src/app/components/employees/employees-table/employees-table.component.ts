import { Component, OnInit } from '@angular/core';


import { ProfessorDto, ProfessorsGrpcDto } from 'src/app/interfaces/professor-dto';
import { ProfessorsGrpcserviceService } from 'src/app/services/professors-grpcservice.service';

@Component({
    selector: 'app-employees-table',
    templateUrl: './employees-table.component.html',
    styleUrls: ['./employees-table.component.css']
})
export class EmployeesTableComponent implements OnInit {

    professorsList: ProfessorDto[] = [];
    imageWidth = 50;
    imageHeight = 50;
    imageMargin = 1;
    
    constructor(private professorsGrpcserviceService: ProfessorsGrpcserviceService) {
    }

    ngOnInit(): void {
        this.loadAllProfessors();
    }

    loadAllProfessors() {
        this.professorsGrpcserviceService
            .GetAllProfessorsFromgRPC()
            .then((results: any) => {
                console.log(`Inside UI Results: ${results}`);
                this.professorsList = results.professorsList;
            });
    }

}
