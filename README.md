# IDCT-Proj-Unity
 tic-tac-toe ui and game-logic 


Proto (for C# Client , env=win32)
```cmd
protoc -I=.\Assets\Protos -I=%proto_path%\include -I=%proto_path%\googleapis --csharp_out=.\Assets\Protos .\Assets\Protos\*.proto --grpc_out=.\Assets\Protos --plugin=protoc-gen-grpc=%proto_path%\bin\grpc_csharp_plugin.exe 
```

```cmd
protoc -I=.\Assets\Protos\v2 -I=%proto_path%\include -I=%proto_path%\googleapis --csharp_out=.\Assets\Protos\v2 .\Assets\Protos\v2\*.proto --grpc_out=.\Assets\Protos --plugin=protoc-gen-grpc=%proto_path%\bin\grpc_csharp_plugin.exe 

```
