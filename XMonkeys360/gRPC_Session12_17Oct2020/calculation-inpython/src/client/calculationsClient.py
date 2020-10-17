
from __future__ import print_function
import logging
import grpc

import sys
sys.path.insert(0, '../protos/generated')
import calculations_pb2_grpc as calculations_service
import calculations_pb2 as calculations_messages

class CalculationsClient(calculations_service.CalculationServiceStub):

    def __init__(self, value1, value2):
        self.value1 = value1
        self.value2 = value2

    def invoke_add_numbers(self):

        with grpc.insecure_channel('localhost:50051') as channel:

            stub = calculations_service.CalculationServiceStub(channel)

            print("Invoking AddNumbers() in gRPC Server.")

            response = stub.AddNumbers(calculations_messages.AddRequest(value1=self.value1, value2=self.value2))

            print("Output received: ", response.sum)


def main():
    client = CalculationsClient(1001, 2002)
    client.invoke_add_numbers()

if __name__ == '__main__':
    logging.basicConfig()

    main()
