// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GameCtlv2.proto
// </auto-generated>
// Original file comments:
// # hello.proto
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace PlayCli.ProtoMod {
  public static partial class RoomStatus
  {
    static readonly string __ServiceName = "RoomStatus.RoomStatus";

    static readonly grpc::Marshaller<global::PlayCli.ProtoMod.RoomCreateReq> __Marshaller_RoomStatus_RoomCreateReq = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PlayCli.ProtoMod.RoomCreateReq.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PlayCli.ProtoMod.RoomResp> __Marshaller_RoomStatus_RoomResp = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PlayCli.ProtoMod.RoomResp.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PlayCli.ProtoMod.RoomListReq> __Marshaller_RoomStatus_RoomListReq = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PlayCli.ProtoMod.RoomListReq.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PlayCli.ProtoMod.RoomListResp> __Marshaller_RoomStatus_RoomListResp = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PlayCli.ProtoMod.RoomListResp.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PlayCli.ProtoMod.RoomReq> __Marshaller_RoomStatus_RoomReq = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PlayCli.ProtoMod.RoomReq.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PlayCli.ProtoMod.CellStatusReq> __Marshaller_RoomStatus_CellStatusReq = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PlayCli.ProtoMod.CellStatusReq.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PlayCli.ProtoMod.CellStatusResp> __Marshaller_RoomStatus_CellStatusResp = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PlayCli.ProtoMod.CellStatusResp.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);

    static readonly grpc::Method<global::PlayCli.ProtoMod.RoomCreateReq, global::PlayCli.ProtoMod.RoomResp> __Method_CreateRoom = new grpc::Method<global::PlayCli.ProtoMod.RoomCreateReq, global::PlayCli.ProtoMod.RoomResp>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateRoom",
        __Marshaller_RoomStatus_RoomCreateReq,
        __Marshaller_RoomStatus_RoomResp);

    static readonly grpc::Method<global::PlayCli.ProtoMod.RoomListReq, global::PlayCli.ProtoMod.RoomListResp> __Method_GetRoomList = new grpc::Method<global::PlayCli.ProtoMod.RoomListReq, global::PlayCli.ProtoMod.RoomListResp>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetRoomList",
        __Marshaller_RoomStatus_RoomListReq,
        __Marshaller_RoomStatus_RoomListResp);

    static readonly grpc::Method<global::PlayCli.ProtoMod.RoomReq, global::PlayCli.ProtoMod.RoomResp> __Method_GetRoomInfo = new grpc::Method<global::PlayCli.ProtoMod.RoomReq, global::PlayCli.ProtoMod.RoomResp>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetRoomInfo",
        __Marshaller_RoomStatus_RoomReq,
        __Marshaller_RoomStatus_RoomResp);

    static readonly grpc::Method<global::PlayCli.ProtoMod.RoomReq, global::PlayCli.ProtoMod.RoomResp> __Method_DeleteRoom = new grpc::Method<global::PlayCli.ProtoMod.RoomReq, global::PlayCli.ProtoMod.RoomResp>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteRoom",
        __Marshaller_RoomStatus_RoomReq,
        __Marshaller_RoomStatus_RoomResp);

    static readonly grpc::Method<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp> __Method_RoomStream = new grpc::Method<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "RoomStream",
        __Marshaller_RoomStatus_CellStatusReq,
        __Marshaller_RoomStatus_CellStatusResp);

    static readonly grpc::Method<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp> __Method_GetRoomStream = new grpc::Method<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetRoomStream",
        __Marshaller_RoomStatus_CellStatusReq,
        __Marshaller_RoomStatus_CellStatusResp);

    static readonly grpc::Method<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp> __Method_UpdateRoom = new grpc::Method<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateRoom",
        __Marshaller_RoomStatus_CellStatusReq,
        __Marshaller_RoomStatus_CellStatusResp);

    static readonly grpc::Method<global::PlayCli.ProtoMod.RoomCreateReq, global::Google.Protobuf.WellKnownTypes.Empty> __Method_QuitRoom = new grpc::Method<global::PlayCli.ProtoMod.RoomCreateReq, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "QuitRoom",
        __Marshaller_RoomStatus_RoomCreateReq,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::PlayCli.ProtoMod.GameCtlv2Reflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of RoomStatus</summary>
    [grpc::BindServiceMethod(typeof(RoomStatus), "BindService")]
    public abstract partial class RoomStatusBase
    {
      public virtual global::System.Threading.Tasks.Task<global::PlayCli.ProtoMod.RoomResp> CreateRoom(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PlayCli.ProtoMod.RoomListResp> GetRoomList(global::PlayCli.ProtoMod.RoomListReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PlayCli.ProtoMod.RoomResp> GetRoomInfo(global::PlayCli.ProtoMod.RoomReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PlayCli.ProtoMod.RoomResp> DeleteRoom(global::PlayCli.ProtoMod.RoomReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task RoomStream(grpc::IAsyncStreamReader<global::PlayCli.ProtoMod.CellStatusReq> requestStream, grpc::IServerStreamWriter<global::PlayCli.ProtoMod.CellStatusResp> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task GetRoomStream(global::PlayCli.ProtoMod.CellStatusReq request, grpc::IServerStreamWriter<global::PlayCli.ProtoMod.CellStatusResp> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PlayCli.ProtoMod.CellStatusResp> UpdateRoom(global::PlayCli.ProtoMod.CellStatusReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> QuitRoom(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for RoomStatus</summary>
    public partial class RoomStatusClient : grpc::ClientBase<RoomStatusClient>
    {
      /// <summary>Creates a new client for RoomStatus</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public RoomStatusClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for RoomStatus that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public RoomStatusClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected RoomStatusClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected RoomStatusClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::PlayCli.ProtoMod.RoomResp CreateRoom(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateRoom(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::PlayCli.ProtoMod.RoomResp CreateRoom(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateRoom, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.RoomResp> CreateRoomAsync(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateRoomAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.RoomResp> CreateRoomAsync(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateRoom, null, options, request);
      }
      public virtual global::PlayCli.ProtoMod.RoomListResp GetRoomList(global::PlayCli.ProtoMod.RoomListReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetRoomList(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::PlayCli.ProtoMod.RoomListResp GetRoomList(global::PlayCli.ProtoMod.RoomListReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetRoomList, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.RoomListResp> GetRoomListAsync(global::PlayCli.ProtoMod.RoomListReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetRoomListAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.RoomListResp> GetRoomListAsync(global::PlayCli.ProtoMod.RoomListReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetRoomList, null, options, request);
      }
      public virtual global::PlayCli.ProtoMod.RoomResp GetRoomInfo(global::PlayCli.ProtoMod.RoomReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetRoomInfo(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::PlayCli.ProtoMod.RoomResp GetRoomInfo(global::PlayCli.ProtoMod.RoomReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetRoomInfo, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.RoomResp> GetRoomInfoAsync(global::PlayCli.ProtoMod.RoomReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetRoomInfoAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.RoomResp> GetRoomInfoAsync(global::PlayCli.ProtoMod.RoomReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetRoomInfo, null, options, request);
      }
      public virtual global::PlayCli.ProtoMod.RoomResp DeleteRoom(global::PlayCli.ProtoMod.RoomReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteRoom(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::PlayCli.ProtoMod.RoomResp DeleteRoom(global::PlayCli.ProtoMod.RoomReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteRoom, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.RoomResp> DeleteRoomAsync(global::PlayCli.ProtoMod.RoomReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteRoomAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.RoomResp> DeleteRoomAsync(global::PlayCli.ProtoMod.RoomReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteRoom, null, options, request);
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp> RoomStream(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RoomStream(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp> RoomStream(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_RoomStream, null, options);
      }
      public virtual grpc::AsyncServerStreamingCall<global::PlayCli.ProtoMod.CellStatusResp> GetRoomStream(global::PlayCli.ProtoMod.CellStatusReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetRoomStream(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::PlayCli.ProtoMod.CellStatusResp> GetRoomStream(global::PlayCli.ProtoMod.CellStatusReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetRoomStream, null, options, request);
      }
      public virtual global::PlayCli.ProtoMod.CellStatusResp UpdateRoom(global::PlayCli.ProtoMod.CellStatusReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateRoom(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::PlayCli.ProtoMod.CellStatusResp UpdateRoom(global::PlayCli.ProtoMod.CellStatusReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateRoom, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.CellStatusResp> UpdateRoomAsync(global::PlayCli.ProtoMod.CellStatusReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateRoomAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::PlayCli.ProtoMod.CellStatusResp> UpdateRoomAsync(global::PlayCli.ProtoMod.CellStatusReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateRoom, null, options, request);
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty QuitRoom(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return QuitRoom(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty QuitRoom(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_QuitRoom, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> QuitRoomAsync(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return QuitRoomAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> QuitRoomAsync(global::PlayCli.ProtoMod.RoomCreateReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_QuitRoom, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override RoomStatusClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new RoomStatusClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(RoomStatusBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CreateRoom, serviceImpl.CreateRoom)
          .AddMethod(__Method_GetRoomList, serviceImpl.GetRoomList)
          .AddMethod(__Method_GetRoomInfo, serviceImpl.GetRoomInfo)
          .AddMethod(__Method_DeleteRoom, serviceImpl.DeleteRoom)
          .AddMethod(__Method_RoomStream, serviceImpl.RoomStream)
          .AddMethod(__Method_GetRoomStream, serviceImpl.GetRoomStream)
          .AddMethod(__Method_UpdateRoom, serviceImpl.UpdateRoom)
          .AddMethod(__Method_QuitRoom, serviceImpl.QuitRoom).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, RoomStatusBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CreateRoom, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PlayCli.ProtoMod.RoomCreateReq, global::PlayCli.ProtoMod.RoomResp>(serviceImpl.CreateRoom));
      serviceBinder.AddMethod(__Method_GetRoomList, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PlayCli.ProtoMod.RoomListReq, global::PlayCli.ProtoMod.RoomListResp>(serviceImpl.GetRoomList));
      serviceBinder.AddMethod(__Method_GetRoomInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PlayCli.ProtoMod.RoomReq, global::PlayCli.ProtoMod.RoomResp>(serviceImpl.GetRoomInfo));
      serviceBinder.AddMethod(__Method_DeleteRoom, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PlayCli.ProtoMod.RoomReq, global::PlayCli.ProtoMod.RoomResp>(serviceImpl.DeleteRoom));
      serviceBinder.AddMethod(__Method_RoomStream, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp>(serviceImpl.RoomStream));
      serviceBinder.AddMethod(__Method_GetRoomStream, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp>(serviceImpl.GetRoomStream));
      serviceBinder.AddMethod(__Method_UpdateRoom, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PlayCli.ProtoMod.CellStatusReq, global::PlayCli.ProtoMod.CellStatusResp>(serviceImpl.UpdateRoom));
      serviceBinder.AddMethod(__Method_QuitRoom, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PlayCli.ProtoMod.RoomCreateReq, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.QuitRoom));
    }

  }
}
#endregion