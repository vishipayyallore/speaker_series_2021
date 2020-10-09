import { Timestamp } from 'google-protobuf/google/protobuf/timestamp_pb';

export interface ProfessorDto {
  professorid: string;
  name: string;
  doj: Timestamp;
  teaches: string;
  salary: number;
  isphd: boolean;
}

export interface AddProfessorDto {
  name: string;
  doj: Date;
  teaches: string;
  salary: number;
  isPhd: boolean;
}

export interface ProfessorsFromGrpc {
  count: number;
  message: string;
  professorsList: ProfessorDto[];
}
