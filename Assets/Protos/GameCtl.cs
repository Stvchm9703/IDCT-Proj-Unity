// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GameCtl.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace PlayCli.ProtoMod {

  /// <summary>Holder for reflection information generated from GameCtl.proto</summary>
  public static partial class GameCtlReflection {

    #region Descriptor
    /// <summary>File descriptor for GameCtl.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GameCtlReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg1HYW1lQ3RsLnByb3RvEgpSb29tU3RhdHVzIgcKBUVtcHR5IiYKD1Jvb21M",
            "aXN0UmVxdWVzdBITCgtyZXF1aXJlbWVudBgBIAEoCSI0ChBSb29tTGlzdFJl",
            "c3BvbnNlEiAKBnJlc3VsdBgBIAMoCzIQLlJvb21TdGF0dXMuUm9vbSIaCgtS",
            "b29tUmVxdWVzdBILCgNrZXkYASABKAki7AEKBFJvb20SCwoDa2V5GAEgASgJ",
            "Eg8KB2hvc3RfaWQYAiABKAkSJwoGc3RhdHVzGAMgASgOMhcuUm9vbVN0YXR1",
            "cy5Sb29tLlN0YXR1cxINCgVyb3VuZBgEIAEoBRIMCgRjZWxsGAUgASgFEisK",
            "C2NlbGxfc3RhdHVzGAYgAygLMhYuUm9vbVN0YXR1cy5DZWxsU3RhdHVzIlMK",
            "BlN0YXR1cxIMCghPTl9TVEFSVBAAEgsKB09OX1dBSVQQARIQCgxPTl9IT1NU",
            "X1RVUk4QAhIQCgxPTl9EVUVMX1RVUk4QAxIKCgZPTl9FTkQQBCI5CgpDZWxs",
            "U3RhdHVzEgsKA2tleRgBIAEoCRIMCgR0dXJuGAIgASgFEhAKCGNlbGxfbnVt",
            "GAMgASgFMocDCgpSb29tU3RhdHVzEjEKCkNyZWF0ZVJvb20SES5Sb29tU3Rh",
            "dHVzLkVtcHR5GhAuUm9vbVN0YXR1cy5Sb29tEkgKC0dldFJvb21MaXN0Ehsu",
            "Um9vbVN0YXR1cy5Sb29tTGlzdFJlcXVlc3QaHC5Sb29tU3RhdHVzLlJvb21M",
            "aXN0UmVzcG9uc2USPwoSR2V0Um9vbUN1cnJlbnRJbmZvEhcuUm9vbVN0YXR1",
            "cy5Sb29tUmVxdWVzdBoQLlJvb21TdGF0dXMuUm9vbRJCCg1HZXRSb29tU3Ry",
            "ZWFtEhcuUm9vbVN0YXR1cy5Sb29tUmVxdWVzdBoWLlJvb21TdGF0dXMuQ2Vs",
            "bFN0YXR1czABEj0KEFVwZGF0ZVJvb21TdGF0dXMSFi5Sb29tU3RhdHVzLkNl",
            "bGxTdGF0dXMaES5Sb29tU3RhdHVzLkVtcHR5EjgKCkRlbGV0ZVJvb20SFy5S",
            "b29tU3RhdHVzLlJvb21SZXF1ZXN0GhEuUm9vbVN0YXR1cy5FbXB0eUITqgIQ",
            "UGxheUNsaS5Qcm90b01vZGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::PlayCli.ProtoMod.Empty), global::PlayCli.ProtoMod.Empty.Parser, null, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PlayCli.ProtoMod.RoomListRequest), global::PlayCli.ProtoMod.RoomListRequest.Parser, new[]{ "Requirement" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PlayCli.ProtoMod.RoomListResponse), global::PlayCli.ProtoMod.RoomListResponse.Parser, new[]{ "Result" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PlayCli.ProtoMod.RoomRequest), global::PlayCli.ProtoMod.RoomRequest.Parser, new[]{ "Key" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PlayCli.ProtoMod.Room), global::PlayCli.ProtoMod.Room.Parser, new[]{ "Key", "HostId", "Status", "Round", "Cell", "CellStatus" }, null, new[]{ typeof(global::PlayCli.ProtoMod.Room.Types.Status) }, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PlayCli.ProtoMod.CellStatus), global::PlayCli.ProtoMod.CellStatus.Parser, new[]{ "Key", "Turn", "CellNum" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Empty : pb::IMessage<Empty> {
    private static readonly pb::MessageParser<Empty> _parser = new pb::MessageParser<Empty>(() => new Empty());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Empty> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PlayCli.ProtoMod.GameCtlReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Empty() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Empty(Empty other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Empty Clone() {
      return new Empty(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Empty);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Empty other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Empty other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class RoomListRequest : pb::IMessage<RoomListRequest> {
    private static readonly pb::MessageParser<RoomListRequest> _parser = new pb::MessageParser<RoomListRequest>(() => new RoomListRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RoomListRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PlayCli.ProtoMod.GameCtlReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomListRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomListRequest(RoomListRequest other) : this() {
      requirement_ = other.requirement_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomListRequest Clone() {
      return new RoomListRequest(this);
    }

    /// <summary>Field number for the "requirement" field.</summary>
    public const int RequirementFieldNumber = 1;
    private string requirement_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Requirement {
      get { return requirement_; }
      set {
        requirement_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RoomListRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RoomListRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Requirement != other.Requirement) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Requirement.Length != 0) hash ^= Requirement.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Requirement.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Requirement);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Requirement.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Requirement);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RoomListRequest other) {
      if (other == null) {
        return;
      }
      if (other.Requirement.Length != 0) {
        Requirement = other.Requirement;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Requirement = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class RoomListResponse : pb::IMessage<RoomListResponse> {
    private static readonly pb::MessageParser<RoomListResponse> _parser = new pb::MessageParser<RoomListResponse>(() => new RoomListResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RoomListResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PlayCli.ProtoMod.GameCtlReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomListResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomListResponse(RoomListResponse other) : this() {
      result_ = other.result_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomListResponse Clone() {
      return new RoomListResponse(this);
    }

    /// <summary>Field number for the "result" field.</summary>
    public const int ResultFieldNumber = 1;
    private static readonly pb::FieldCodec<global::PlayCli.ProtoMod.Room> _repeated_result_codec
        = pb::FieldCodec.ForMessage(10, global::PlayCli.ProtoMod.Room.Parser);
    private readonly pbc::RepeatedField<global::PlayCli.ProtoMod.Room> result_ = new pbc::RepeatedField<global::PlayCli.ProtoMod.Room>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::PlayCli.ProtoMod.Room> Result {
      get { return result_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RoomListResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RoomListResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!result_.Equals(other.result_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= result_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      result_.WriteTo(output, _repeated_result_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += result_.CalculateSize(_repeated_result_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RoomListResponse other) {
      if (other == null) {
        return;
      }
      result_.Add(other.result_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            result_.AddEntriesFrom(input, _repeated_result_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class RoomRequest : pb::IMessage<RoomRequest> {
    private static readonly pb::MessageParser<RoomRequest> _parser = new pb::MessageParser<RoomRequest>(() => new RoomRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RoomRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PlayCli.ProtoMod.GameCtlReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomRequest(RoomRequest other) : this() {
      key_ = other.key_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomRequest Clone() {
      return new RoomRequest(this);
    }

    /// <summary>Field number for the "key" field.</summary>
    public const int KeyFieldNumber = 1;
    private string key_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Key {
      get { return key_; }
      set {
        key_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RoomRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RoomRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Key != other.Key) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Key.Length != 0) hash ^= Key.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Key.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Key);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Key.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Key);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RoomRequest other) {
      if (other == null) {
        return;
      }
      if (other.Key.Length != 0) {
        Key = other.Key;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Key = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Room : pb::IMessage<Room> {
    private static readonly pb::MessageParser<Room> _parser = new pb::MessageParser<Room>(() => new Room());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Room> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PlayCli.ProtoMod.GameCtlReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Room() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Room(Room other) : this() {
      key_ = other.key_;
      hostId_ = other.hostId_;
      status_ = other.status_;
      round_ = other.round_;
      cell_ = other.cell_;
      cellStatus_ = other.cellStatus_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Room Clone() {
      return new Room(this);
    }

    /// <summary>Field number for the "key" field.</summary>
    public const int KeyFieldNumber = 1;
    private string key_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Key {
      get { return key_; }
      set {
        key_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "host_id" field.</summary>
    public const int HostIdFieldNumber = 2;
    private string hostId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string HostId {
      get { return hostId_; }
      set {
        hostId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 3;
    private global::PlayCli.ProtoMod.Room.Types.Status status_ = global::PlayCli.ProtoMod.Room.Types.Status.OnStart;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::PlayCli.ProtoMod.Room.Types.Status Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    /// <summary>Field number for the "round" field.</summary>
    public const int RoundFieldNumber = 4;
    private int round_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Round {
      get { return round_; }
      set {
        round_ = value;
      }
    }

    /// <summary>Field number for the "cell" field.</summary>
    public const int CellFieldNumber = 5;
    private int cell_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Cell {
      get { return cell_; }
      set {
        cell_ = value;
      }
    }

    /// <summary>Field number for the "cell_status" field.</summary>
    public const int CellStatusFieldNumber = 6;
    private static readonly pb::FieldCodec<global::PlayCli.ProtoMod.CellStatus> _repeated_cellStatus_codec
        = pb::FieldCodec.ForMessage(50, global::PlayCli.ProtoMod.CellStatus.Parser);
    private readonly pbc::RepeatedField<global::PlayCli.ProtoMod.CellStatus> cellStatus_ = new pbc::RepeatedField<global::PlayCli.ProtoMod.CellStatus>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::PlayCli.ProtoMod.CellStatus> CellStatus {
      get { return cellStatus_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Room);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Room other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Key != other.Key) return false;
      if (HostId != other.HostId) return false;
      if (Status != other.Status) return false;
      if (Round != other.Round) return false;
      if (Cell != other.Cell) return false;
      if(!cellStatus_.Equals(other.cellStatus_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Key.Length != 0) hash ^= Key.GetHashCode();
      if (HostId.Length != 0) hash ^= HostId.GetHashCode();
      if (Status != global::PlayCli.ProtoMod.Room.Types.Status.OnStart) hash ^= Status.GetHashCode();
      if (Round != 0) hash ^= Round.GetHashCode();
      if (Cell != 0) hash ^= Cell.GetHashCode();
      hash ^= cellStatus_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Key.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Key);
      }
      if (HostId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(HostId);
      }
      if (Status != global::PlayCli.ProtoMod.Room.Types.Status.OnStart) {
        output.WriteRawTag(24);
        output.WriteEnum((int) Status);
      }
      if (Round != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Round);
      }
      if (Cell != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Cell);
      }
      cellStatus_.WriteTo(output, _repeated_cellStatus_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Key.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Key);
      }
      if (HostId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(HostId);
      }
      if (Status != global::PlayCli.ProtoMod.Room.Types.Status.OnStart) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Status);
      }
      if (Round != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Round);
      }
      if (Cell != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Cell);
      }
      size += cellStatus_.CalculateSize(_repeated_cellStatus_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Room other) {
      if (other == null) {
        return;
      }
      if (other.Key.Length != 0) {
        Key = other.Key;
      }
      if (other.HostId.Length != 0) {
        HostId = other.HostId;
      }
      if (other.Status != global::PlayCli.ProtoMod.Room.Types.Status.OnStart) {
        Status = other.Status;
      }
      if (other.Round != 0) {
        Round = other.Round;
      }
      if (other.Cell != 0) {
        Cell = other.Cell;
      }
      cellStatus_.Add(other.cellStatus_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Key = input.ReadString();
            break;
          }
          case 18: {
            HostId = input.ReadString();
            break;
          }
          case 24: {
            Status = (global::PlayCli.ProtoMod.Room.Types.Status) input.ReadEnum();
            break;
          }
          case 32: {
            Round = input.ReadInt32();
            break;
          }
          case 40: {
            Cell = input.ReadInt32();
            break;
          }
          case 50: {
            cellStatus_.AddEntriesFrom(input, _repeated_cellStatus_codec);
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the Room message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum Status {
        [pbr::OriginalName("ON_START")] OnStart = 0,
        [pbr::OriginalName("ON_WAIT")] OnWait = 1,
        [pbr::OriginalName("ON_HOST_TURN")] OnHostTurn = 2,
        [pbr::OriginalName("ON_DUEL_TURN")] OnDuelTurn = 3,
        [pbr::OriginalName("ON_END")] OnEnd = 4,
      }

    }
    #endregion

  }

  public sealed partial class CellStatus : pb::IMessage<CellStatus> {
    private static readonly pb::MessageParser<CellStatus> _parser = new pb::MessageParser<CellStatus>(() => new CellStatus());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CellStatus> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PlayCli.ProtoMod.GameCtlReflection.Descriptor.MessageTypes[5]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CellStatus() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CellStatus(CellStatus other) : this() {
      key_ = other.key_;
      turn_ = other.turn_;
      cellNum_ = other.cellNum_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CellStatus Clone() {
      return new CellStatus(this);
    }

    /// <summary>Field number for the "key" field.</summary>
    public const int KeyFieldNumber = 1;
    private string key_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Key {
      get { return key_; }
      set {
        key_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "turn" field.</summary>
    public const int TurnFieldNumber = 2;
    private int turn_;
    /// <summary>
    /// turn 1 = host / -1 = duel
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Turn {
      get { return turn_; }
      set {
        turn_ = value;
      }
    }

    /// <summary>Field number for the "cell_num" field.</summary>
    public const int CellNumFieldNumber = 3;
    private int cellNum_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CellNum {
      get { return cellNum_; }
      set {
        cellNum_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CellStatus);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CellStatus other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Key != other.Key) return false;
      if (Turn != other.Turn) return false;
      if (CellNum != other.CellNum) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Key.Length != 0) hash ^= Key.GetHashCode();
      if (Turn != 0) hash ^= Turn.GetHashCode();
      if (CellNum != 0) hash ^= CellNum.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Key.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Key);
      }
      if (Turn != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Turn);
      }
      if (CellNum != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(CellNum);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Key.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Key);
      }
      if (Turn != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Turn);
      }
      if (CellNum != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(CellNum);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CellStatus other) {
      if (other == null) {
        return;
      }
      if (other.Key.Length != 0) {
        Key = other.Key;
      }
      if (other.Turn != 0) {
        Turn = other.Turn;
      }
      if (other.CellNum != 0) {
        CellNum = other.CellNum;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Key = input.ReadString();
            break;
          }
          case 16: {
            Turn = input.ReadInt32();
            break;
          }
          case 24: {
            CellNum = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
