# Simple gRPC Sample in Python

## Packages to be installed

1. python -m pip install --upgrade pip
2. python -m pip install grpcio
3. python -m pip install grpcio-tools

## To Generate the files using protoc

**We need to specify the absolute path**

Execute the below mentioned command inside the **Protos** folder

```
python -m grpc_tools.protoc -I=D:\LordKrishna\GitHub\mini-projects-2020\Projects\grpc-helloworld\calculation-inpython\src\protos --python_out=D:\LordKrishna\GitHub\mini-projects-2020\Projects\grpc-helloworld\calculation-inpython\src\protos\generated --grpc_python_out=D:\LordKrishna\GitHub\mini-projects-2020\Projects\grpc-helloworld\calculation-inpython\src\protos\generated calculations.proto
```

