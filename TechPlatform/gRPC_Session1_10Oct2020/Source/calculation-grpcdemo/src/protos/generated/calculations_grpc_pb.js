// GENERATED CODE -- DO NOT EDIT!

'use strict';
var grpc = require('grpc');
var calculations_pb = require('./calculations_pb.js');

function serialize_calculations_AddRequest(arg) {
  if (!(arg instanceof calculations_pb.AddRequest)) {
    throw new Error('Expected argument of type calculations.AddRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_calculations_AddRequest(buffer_arg) {
  return calculations_pb.AddRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_calculations_AddResponse(arg) {
  if (!(arg instanceof calculations_pb.AddResponse)) {
    throw new Error('Expected argument of type calculations.AddResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_calculations_AddResponse(buffer_arg) {
  return calculations_pb.AddResponse.deserializeBinary(new Uint8Array(buffer_arg));
}


var CalculationServiceService = exports.CalculationServiceService = {
  // Unary API
addNumbers: {
    path: '/calculations.CalculationService/AddNumbers',
    requestStream: false,
    responseStream: false,
    requestType: calculations_pb.AddRequest,
    responseType: calculations_pb.AddResponse,
    requestSerialize: serialize_calculations_AddRequest,
    requestDeserialize: deserialize_calculations_AddRequest,
    responseSerialize: serialize_calculations_AddResponse,
    responseDeserialize: deserialize_calculations_AddResponse,
  },
};

exports.CalculationServiceClient = grpc.makeGenericClientConstructor(CalculationServiceService);
