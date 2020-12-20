'use strict';

const grpc = require("grpc");

const calculation = require("../protos/generated/calculations_pb");
const calculationService = require("../protos/generated/calculations_grpc_pb");

const serverPort = "127.0.0.1:6002";

const main = () => {

    console.log(`Node JS gRPC Client started ...`);

    // Initializing the Client
    const gRPCClient = new calculationService.CalculationServiceClient(serverPort, grpc.credentials.createInsecure());

    // Creating the Request
    const addRequest = new calculation.AddRequest();
    addRequest.setValue1(10);
    addRequest.setValue2(20);

    console.log(`Invoking the addNumbers from gRPC Server ...`);
    gRPCClient.addNumbers(addRequest, (error, response) => {

        if (error) {
            console.error(`Error occurred while invoking gRPC Server. Message: ${error}`);
        } else {
            console.log(`Addition Results: ${response.getSum()}`);
        }

    });
}

// Invoking the main method
main();