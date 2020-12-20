# Simple gRPC Sample in Node JS

## Packages to be installed

1. npm i google-protobuf
2. npm i grpc
3. npm i grpc-tools
4. npm i protoc-gen-grpc


## To Generate the files using protoc

**We need to specify the absolute path**

protoc -I=D:/LordKrishna/GitHub/learning_node_in_2020/calculation-grpcdemo/src/protos D:/LordKrishna/GitHub/learning_node_in_2020/calculation-grpcdemo/src/protos/calculations.proto --js_out=import_style=commonjs,binary:D:/LordKrishna/GitHub/learning_node_in_2020/calculation-grpcdemo/src/protos --grpc_out=D:/LordKrishna/GitHub/learning_node_in_2020/calculation-grpcdemo/src/protos --plugin=protoc-gen-grpc=D:/LordKrishna/GitHub/learning_node_in_2020/calculation-grpcdemo/node_modules/.bin/grpc_tools_node_protoc_plugin.cmd

To get started, make sure to install the NPM dependencies:
`$ npm install`

