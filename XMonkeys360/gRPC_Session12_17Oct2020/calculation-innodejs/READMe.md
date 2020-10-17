# Simple gRPC Sample in Node JS

## Packages to be installed

1. npm i google-protobuf
2. npm i grpc
3. npm i grpc-tools
4. npm i protoc-gen-grpc

## To Generate the files using protoc

Execute the below mentioned command from the root folder example **D:/LordKrishna/GitHub/mini-projects-2020/Projects/grpc-helloworld/calculation-innodejs** where package.json file exists.

**We need to specify the absolute path**

protoc -I=D:/LordKrishna/GitHub/mini-projects-2020/Projects/grpc-helloworld/calculation-innodejs/src/protos D:/LordKrishna/GitHub/mini-projects-2020/Projects/grpc-helloworld/calculation-innodejs/src/protos/calculations.proto --js_out=import_style=commonjs,binary:D:/LordKrishna/GitHub/mini-projects-2020/Projects/grpc-helloworld/calculation-innodejs/src/protos/generated --grpc_out=D:/LordKrishna/GitHub/mini-projects-2020/Projects/grpc-helloworld/calculation-innodejs/src/protos/generated --plugin=protoc-gen-grpc=D:/LordKrishna/GitHub/learning_node_in_2020/calculation-grpcdemo/node_modules/.bin/grpc_tools_node_protoc_plugin.cmd

To get started, make sure to install the NPM dependencies:
`$ npm install`

### Original Command
protoc -I=D:/LordKrishna/Working/grpc-helloworld/calculation-innodejs/src/protos D:/LordKrishna/Working/grpc-helloworld/calculation-innodejs/src/protos/calculations.proto --js_out=import_style=commonjs,binary:D:/LordKrishna/Working/grpc-helloworld/calculation-innodejs/src/protos/generated --grpc_out=D:/LordKrishna/Working/grpc-helloworld/calculation-innodejs/src/protos/generated --plugin=protoc-gen-grpc=D:/LordKrishna/Working/grpc-helloworld/calculation-innodejs/node_modules/.bin/grpc_tools_node_protoc_plugin.cmd
