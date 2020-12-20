from concurrent import futures
import logging
import grpc

import sys
sys.path.insert(0, '../protos/generated')
import calculations_pb2_grpc as calculations_service
import calculations_pb2 as calculations_messages


class CalculationsServer(calculations_service.CalculationServiceServicer):

    def __init__(self, *args, **kwargs):
        pass

    def AddNumbers(self, request, context):

        # get the numbers incoming request
        value1 = int(request.value1)
        value2 = int(request.value2)
        print('Received the AddNumbers request with', value1, value2)

        sum = value1 + value2

        result = {'sum': sum}

        print('Sending the AddNumbers response', sum)
        return calculations_messages.AddResponse(**result)


def start_grpc_server():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))

    calculations_service.add_CalculationServiceServicer_to_server( CalculationsServer(), server)

    server.add_insecure_port('[::]:50051')
    server.start()

    print('Server listening at http://localhost:50051')
    server.wait_for_termination()


if __name__ == '__main__':
    start_grpc_server()
