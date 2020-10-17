# Simple gRPC Sample in Golang

## Packages to be installed

1. go get github.com/golang/protobuf/protoc-gen-go
2. go get google.golang.org/grpc/cmd/protoc-gen-go-grpc
3. go get -u google.golang.org/grpc

## To Generate the files using protoc

**We need to specify the absolute path**

Execute the below mentioned command inside the **Protos** folder

```
protoc --go_out=. --go_opt=paths=source_relative --go-grpc_out=. --go-grpc_opt=paths=source_relative calculations.proto
```


