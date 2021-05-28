// package: 
// file: src/app/proto/college.proto

import * as src_app_proto_college_pb from "../../../src/app/proto/college_pb";
import * as google_protobuf_empty_pb from "google-protobuf/google/protobuf/empty_pb";
import {grpc} from "@improbable-eng/grpc-web";

type CollegeSvcGetAllProfessors = {
  readonly methodName: string;
  readonly service: typeof CollegeSvc;
  readonly requestStream: false;
  readonly responseStream: false;
  readonly requestType: typeof google_protobuf_empty_pb.Empty;
  readonly responseType: typeof src_app_proto_college_pb.AllProfessorsResonse;
};

type CollegeSvcGetProfessorById = {
  readonly methodName: string;
  readonly service: typeof CollegeSvc;
  readonly requestStream: false;
  readonly responseStream: false;
  readonly requestType: typeof src_app_proto_college_pb.GetProfessorRequest;
  readonly responseType: typeof src_app_proto_college_pb.GetProfessorResponse;
};

export class CollegeSvc {
  static readonly serviceName: string;
  static readonly GetAllProfessors: CollegeSvcGetAllProfessors;
  static readonly GetProfessorById: CollegeSvcGetProfessorById;
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

export class CollegeSvcClient {
  readonly serviceHost: string;

  constructor(serviceHost: string, options?: grpc.RpcOptions);
  getAllProfessors(
    requestMessage: google_protobuf_empty_pb.Empty,
    metadata: grpc.Metadata,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_college_pb.AllProfessorsResonse|null) => void
  ): UnaryResponse;
  getAllProfessors(
    requestMessage: google_protobuf_empty_pb.Empty,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_college_pb.AllProfessorsResonse|null) => void
  ): UnaryResponse;
  getProfessorById(
    requestMessage: src_app_proto_college_pb.GetProfessorRequest,
    metadata: grpc.Metadata,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_college_pb.GetProfessorResponse|null) => void
  ): UnaryResponse;
  getProfessorById(
    requestMessage: src_app_proto_college_pb.GetProfessorRequest,
    callback: (error: ServiceError|null, responseMessage: src_app_proto_college_pb.GetProfessorResponse|null) => void
  ): UnaryResponse;
}

