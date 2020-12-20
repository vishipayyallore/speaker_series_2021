// package: collegeapi
// file: src/app/proto/CollegeApi.proto

import * as jspb from "google-protobuf";
import * as google_protobuf_timestamp_pb from "google-protobuf/google/protobuf/timestamp_pb";
import * as google_protobuf_empty_pb from "google-protobuf/google/protobuf/empty_pb";

export class NewProfessorRequest extends jspb.Message {
  getName(): string;
  setName(value: string): void;

  hasDoj(): boolean;
  clearDoj(): void;
  getDoj(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setDoj(value?: google_protobuf_timestamp_pb.Timestamp): void;

  getTeaches(): string;
  setTeaches(value: string): void;

  getSalary(): number;
  setSalary(value: number): void;

  getIsphd(): boolean;
  setIsphd(value: boolean): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): NewProfessorRequest.AsObject;
  static toObject(includeInstance: boolean, msg: NewProfessorRequest): NewProfessorRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: NewProfessorRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): NewProfessorRequest;
  static deserializeBinaryFromReader(message: NewProfessorRequest, reader: jspb.BinaryReader): NewProfessorRequest;
}

export namespace NewProfessorRequest {
  export type AsObject = {
    name: string,
    doj?: google_protobuf_timestamp_pb.Timestamp.AsObject,
    teaches: string,
    salary: number,
    isphd: boolean,
  }
}

export class NewProfessorResponse extends jspb.Message {
  getProfessorid(): string;
  setProfessorid(value: string): void;

  getMessage(): string;
  setMessage(value: string): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): NewProfessorResponse.AsObject;
  static toObject(includeInstance: boolean, msg: NewProfessorResponse): NewProfessorResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: NewProfessorResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): NewProfessorResponse;
  static deserializeBinaryFromReader(message: NewProfessorResponse, reader: jspb.BinaryReader): NewProfessorResponse;
}

export namespace NewProfessorResponse {
  export type AsObject = {
    professorid: string,
    message: string,
  }
}

export class GetProfessorRequest extends jspb.Message {
  getProfessorid(): string;
  setProfessorid(value: string): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): GetProfessorRequest.AsObject;
  static toObject(includeInstance: boolean, msg: GetProfessorRequest): GetProfessorRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: GetProfessorRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): GetProfessorRequest;
  static deserializeBinaryFromReader(message: GetProfessorRequest, reader: jspb.BinaryReader): GetProfessorRequest;
}

export namespace GetProfessorRequest {
  export type AsObject = {
    professorid: string,
  }
}

export class GetProfessorResponse extends jspb.Message {
  getProfessorid(): string;
  setProfessorid(value: string): void;

  getName(): string;
  setName(value: string): void;

  hasDoj(): boolean;
  clearDoj(): void;
  getDoj(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setDoj(value?: google_protobuf_timestamp_pb.Timestamp): void;

  getTeaches(): string;
  setTeaches(value: string): void;

  getSalary(): number;
  setSalary(value: number): void;

  getIsphd(): boolean;
  setIsphd(value: boolean): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): GetProfessorResponse.AsObject;
  static toObject(includeInstance: boolean, msg: GetProfessorResponse): GetProfessorResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: GetProfessorResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): GetProfessorResponse;
  static deserializeBinaryFromReader(message: GetProfessorResponse, reader: jspb.BinaryReader): GetProfessorResponse;
}

export namespace GetProfessorResponse {
  export type AsObject = {
    professorid: string,
    name: string,
    doj?: google_protobuf_timestamp_pb.Timestamp.AsObject,
    teaches: string,
    salary: number,
    isphd: boolean,
  }
}

export class AllProfessorsResonse extends jspb.Message {
  clearProfessorsList(): void;
  getProfessorsList(): Array<GetProfessorResponse>;
  setProfessorsList(value: Array<GetProfessorResponse>): void;
  addProfessors(value?: GetProfessorResponse, index?: number): GetProfessorResponse;

  getMessage(): string;
  setMessage(value: string): void;

  getCount(): number;
  setCount(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): AllProfessorsResonse.AsObject;
  static toObject(includeInstance: boolean, msg: AllProfessorsResonse): AllProfessorsResonse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: AllProfessorsResonse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): AllProfessorsResonse;
  static deserializeBinaryFromReader(message: AllProfessorsResonse, reader: jspb.BinaryReader): AllProfessorsResonse;
}

export namespace AllProfessorsResonse {
  export type AsObject = {
    professorsList: Array<GetProfessorResponse.AsObject>,
    message: string,
    count: number,
  }
}

