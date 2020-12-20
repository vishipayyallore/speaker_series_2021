import { Guid } from "guid-typescript";

export interface ProfessorDto {
  professorId: Guid;
  name: string;
  doj: Date;
  teaches: string;
  salary: number;
  isPhd: boolean;
}

export interface AddProfessorDto {
  name: string;
  doj: Date;
  teaches: string;
  salary: number;
  isPhd: boolean;
}
