// package: collegeapi
// file: src/app/proto/CollegeApi.proto

import * as src_app_proto_CollegeApi_pb from "../../../src/app/proto/CollegeApi_pb";
import * as google_protobuf_empty_pb from "google-protobuf/google/protobuf/empty_pb";
import {grpc} from "@improbable-eng/grpc-web";

type CollegeServiceAddProfessor = {
  readonly methodName: string;
  readonly service: typeof CollegeService;
  readonly requestStream: false;
  readonly responseStream: false;
  readonly requestType: typeof src_app_proto_CollegeApi_pb.NewProfessorRequest;
  readonly responseType: typeof src_app_proto_CollegeApi_pb.NewProfessorResponse;
};

type CollegeServiceGetProfessorById = {
  readonly methodName: string;
  readonly service: typeof CollegeService;
  readonly requestStream: false;
  readonly responseStream: false;
  readonly requestType: typeof src_app_proto_CollegeApi_pb.GetProfessorRequest;
  readonly responseType: typeof src_app_proto_CollegeApi_pb.GetProfessorResponse;
};

type CollegeServiceGetAllProfessors = {
  readonly methodName: string;
  readonly service: typeof CollegeService;
  readonly requestStream: false;
  readonly responseStream: false;
  readonly requestType: typeof google_protobuf_empty_pb.Empty;
  readonly responseType: typeof src_app_proto_CollegeApi_pb.AllProfessorsResonse;
};

export class CollegeService {
  static readonly serviceName: string;
  static readonly AddProfessor: CollegeServiceAddProfessor;
  static readonly GetProfessorById: CollegeServiceGetProfessorById;
  static readonly GetAllProfessors: CollegeServiceGetAllProfessors;
}

export type ServiceError = { message: string, code: number; metadata: grpc.Metadata }
export type Status = { details: string, code: number; metadata: grpc.Metadata }

interface UnaryResponse {
  cancel(): void;
}
interface ResponseStream<T> {
  cancel(): void;
  on(type: 'data', handler: (message: T) => void): ResponseStream<T>;
  on(type: 'end', handler: (status?: Status) => void): ResponseStream<T>;
  on(type: 'status', handler: (status: Status) => void): ResponseStream<T>;
}
interface RequestStream<T> {
  write(message: T): RequestStream<T>;
  end(): void;
  cancel(): void;
  on(type: 'end', handler: (status?: Status) => void): RequestStream<T>;
  on(type: 'status', handler: (status: Status) => void): RequestStream<T>;
}
interface BidirectionalStream<ReqT, ResT> {
  write(message: ReqT): BidirectionalStream<ReqT, ResT>;
  end(): void;
  cancel(): void;
  on(type: 'data', handler: (message: ResT) => void): BidirectionalStream<ReqT, ResT>;
  on(type: 'end', handler: (status?: Status) => void): BidirectionalStream<ReqT, ResT>;
  on(type: 'status', handler: (status: Status) => void): BidirectionalStream<ReqT, ResT>;
}

export class CollegeServiceClient {
  readonly serviceHost: string;

  constructor(serviceHost: string, options?: grpc.RpcOptions);
  addProfessor(
    requestMessage: src_app_proto_CollegeApi_pb.NewProfessorRequest,
    metadata: grpc.Metadata,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_CollegeApi_pb.NewProfessorResponse|null) => void
  ): UnaryResponse;
  addProfessor(
    requestMessage: src_app_proto_CollegeApi_pb.NewProfessorRequest,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_CollegeApi_pb.NewProfessorResponse|null) => void
  ): UnaryResponse;
  getProfessorById(
    requestMessage: src_app_proto_CollegeApi_pb.GetProfessorRequest,
    metadata: grpc.Metadata,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_CollegeApi_pb.GetProfessorResponse|null) => void
  ): UnaryResponse;
  getProfessorById(
    requestMessage: src_app_proto_CollegeApi_pb.GetProfessorRequest,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_CollegeApi_pb.GetProfessorResponse|null) => void
  ): UnaryResponse;
  getAllProfessors(
    requestMessage: google_protobuf_empty_pb.Empty,
    metadata: grpc.Metadata,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_CollegeApi_pb.AllProfessorsResonse|null) => void
  ): UnaryResponse;
  getAllProfessors(
    requestMessage: google_protobuf_empty_pb.Empty,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_CollegeApi_pb.AllProfessorsResonse|null) => void
  ): UnaryResponse;
}

