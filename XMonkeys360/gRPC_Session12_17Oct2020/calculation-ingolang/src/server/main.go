package main

import (
	"context"
	"log"
	"net"

	"google.golang.org/grpc"
	pb "calculationpb"
)

const (
	port = ":50051"
)

// server is used to implement calculationpb.CalculationService.
type server struct {
	pb.UnimplementedCalculationServiceServer
}

// AddNumbers implements calculationpb.CalculationService
func (s *server) AddNumbers(ctx context.Context, in *pb.AddRequest) (*pb.AddResponse, error) {
	log.Printf("Received: %v %v", in.GetValue1(), in.GetValue2())
	return &pb.AddResponse{Sum: (in.GetValue1() + in.GetValue2()) }, nil
}

func main() {
	lis, err := net.Listen("tcp", port)
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}

	log.Printf("Starting the gRPC Server ...")
	s := grpc.NewServer()
	pb.RegisterCalculationServiceServer(s, &server{})

	log.Printf("gRPC Server running on http://localhost:50051")

	if err := s.Serve(lis); err != nil {
		log.Fatalf("failed to serve: %v", err)
	}
}
