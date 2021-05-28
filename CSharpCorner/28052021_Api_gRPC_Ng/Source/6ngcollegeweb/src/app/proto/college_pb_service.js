// package: 
// file: src/app/proto/college.proto

var src_app_proto_college_pb = require("../../../src/app/proto/college_pb");
var google_protobuf_empty_pb = require("google-protobuf/google/protobuf/empty_pb");
var grpc = require("@improbable-eng/grpc-web").grpc;

var CollegeSvc = (function () {
  function CollegeSvc() {}
  CollegeSvc.serviceName = "CollegeSvc";
  return CollegeSvc;
}());

CollegeSvc.GetAllProfessors = {
  methodName: "GetAllProfessors",
  service: CollegeSvc,
  requestStream: false,
  responseStream: false,
  requestType: google_protobuf_empty_pb.Empty,
  responseType: src_app_proto_college_pb.AllProfessorsResonse
};

CollegeSvc.GetProfessorById = {
  methodName: "GetProfessorById",
  service: CollegeSvc,
  requestStream: false,
  responseStream: false,
  requestType: src_app_proto_college_pb.GetProfessorRequest,
  responseType: src_app_proto_college_pb.GetProfessorResponse
};

exports.CollegeSvc = CollegeSvc;

function CollegeSvcClient(serviceHost, options) {
  this.serviceHost = serviceHost;
  this.options = options || {};
}

CollegeSvcClient.prototype.getAllProfessors = function getAllProfessors(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(CollegeSvc.GetAllProfessors, {
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

CollegeSvcClient.prototype.getProfessorById = function getProfessorById(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(CollegeSvc.GetProfessorById, {
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

exports.CollegeSvcClient = CollegeSvcClient;

