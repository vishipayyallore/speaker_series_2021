// package: collegeapi
// file: src/app/proto/CollegeApi.proto

var src_app_proto_CollegeApi_pb = require("../../../src/app/proto/CollegeApi_pb");
var google_protobuf_empty_pb = require("google-protobuf/google/protobuf/empty_pb");
var grpc = require("@improbable-eng/grpc-web").grpc;

var CollegeService = (function () {
  function CollegeService() {}
  CollegeService.serviceName = "collegeapi.CollegeService";
  return CollegeService;
}());

CollegeService.AddProfessor = {
  methodName: "AddProfessor",
  service: CollegeService,
  requestStream: false,
  responseStream: false,
  requestType: src_app_proto_CollegeApi_pb.NewProfessorRequest,
  responseType: src_app_proto_CollegeApi_pb.NewProfessorResponse
};

CollegeService.GetProfessorById = {
  methodName: "GetProfessorById",
  service: CollegeService,
  requestStream: false,
  responseStream: false,
  requestType: src_app_proto_CollegeApi_pb.GetProfessorRequest,
  responseType: src_app_proto_CollegeApi_pb.GetProfessorResponse
};

CollegeService.GetAllProfessors = {
  methodName: "GetAllProfessors",
  service: CollegeService,
  requestStream: false,
  responseStream: false,
  requestType: google_protobuf_empty_pb.Empty,
  responseType: src_app_proto_CollegeApi_pb.AllProfessorsResonse
};

exports.CollegeService = CollegeService;

function CollegeServiceClient(serviceHost, options) {
  this.serviceHost = serviceHost;
  this.options = options || {};
}

CollegeServiceClient.prototype.addProfessor = function addProfessor(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(CollegeService.AddProfessor, {
    request: requestMessage,
    host: this.serviceHost,
    metadata: metadata,
    transport: this.options.transport,
    debug: this.options.debug,
    onEnd: function (response) {
      if (callback) {
        if (response.status !== grpc.Code.OK) {
          var err = new Error(response.statusMessage);
          err.code = response.status;
          err.metadata = response.trailers;
          callback(err, null);
        } else {
          callback(null, response.message);
        }
      }
    }
  });
  return {
    cancel: function () {
      callback = null;
      client.close();
    }
  };
};

CollegeServiceClient.prototype.getProfessorById = function getProfessorById(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(CollegeService.GetProfessorById, {
    request: requestMessage,
    host: this.serviceHost,
    metadata: metadata,
    transport: this.options.transport,
    debug: this.options.debug,
    onEnd: function (response) {
      if (callback) {
        if (response.status !== grpc.Code.OK) {
          var err = new Error(response.statusMessage);
          err.code = response.status;
          err.metadata = response.trailers;
          callback(err, null);
        } else {
          callback(null, response.message);
        }
      }
    }
  });
  return {
    cancel: function () {
      callback = null;
      client.close();
    }
  };
};

CollegeServiceClient.prototype.getAllProfessors = function getAllProfessors(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(CollegeService.GetAllProfessors, {
    request: requestMessage,
    host: this.serviceHost,
    metadata: metadata,
    transport: this.options.transport,
    debug: this.options.debug,
    onEnd: function (response) {
      if (callback) {
        if (response.status !== grpc.Code.OK) {
          var err = new Error(response.statusMessage);
          err.code = response.status;
          err.metadata = response.trailers;
          callback(err, null);
        } else {
          callback(null, response.message);
        }
      }
    }
  });
  return {
    cancel: function () {
      callback = null;
      client.close();
    }
  };
};

exports.CollegeServiceClient = CollegeServiceClient;

