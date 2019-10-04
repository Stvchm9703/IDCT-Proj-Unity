# IDCT-Proj-Unity
 tic-tac-toe ui and game-logic 


Proto (for C# Client)
```
protoc -I=.\Assets\Protos --csharp_out=.\Assets\Protos .\Assets\Protos\*.proto --grpc_out=.\Assets\Protos --plugin=protoc-gen-grpc=%proto_path%\bin\grpc_csharp_plugin.exe 

```

