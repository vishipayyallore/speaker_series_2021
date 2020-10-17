'use strict';

const grpc = require("grpc");

const calculation = require("../protos/generated/calculations_pb");
const calculationService = require("../protos/generated/calculations_grpc_pb");

function addNumbers(caller, callback) {

    console.log(`Request received for addNumbers(). ${caller.request.getValue1()} ${caller.request.getValue2()}`);

    let addResponse = new calculation.AddResponse();

    addResponse.setSum(
        caller.request.getValue1() + caller.request.getValue2()
    );

    console.log(`Sending the output to client ....`);
    callback(null, addResponse);
}

const serverPort = "127.0.0.1:6002";

const main = () => {

    const gRPCServer = new grpc.Server();

    console.log(`Starting the gRPC Server ....`);
    gRPCServer.addService(calculationService.CalculationServiceService, { addNumbers: addNumbers });
    gRPCServer.bind(serverPort, grpc.ServerCredentials.createInsecure());
    gRPCServer.start();

    console.log(`Server running on http://${serverPort}`);
}

// Invoking the main method
main();