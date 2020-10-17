package main

import (
	"context"
	"log"
	"time"

	"google.golang.org/grpc"
	pb "calculationpb"
)

const (
	address     = "localhost:50051"
)

func main() {

	// Set up a connection to the server.
	conn, err := grpc.Dial(address, grpc.WithInsecure(), grpc.WithBlock())
	if err != nil {
		log.Fatalf("did not connect: %v", err)
	}
	defer conn.Close()
	c := pb.NewCalculationServiceClient(conn)

	// Contact the server and print out its response.
	var number1 int32 = 1001
	var number2 int32 = 2002
	/*
	if len(os.Args) > 2 {
		number1, err := strconv.Atoi(os.Args[1])
		number2, err := strconv.Atoi(os.Args[2])
	}
	*/

	ctx, cancel := context.WithTimeout(context.Background(), time.Second)
	defer cancel()
	r, err := c.AddNumbers(ctx, &pb.AddRequest{Value1: number1, Value2: number2})
	if err != nil {
		log.Fatalf("could not greet: %v", err)
	}
	log.Printf("Sum: %d", r.GetSum())
}
