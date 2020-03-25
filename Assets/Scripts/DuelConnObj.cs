using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using PlayCli;
using PlayCli.ProtoMod;
// using SocketIOClient;
using UnityEngine;
// using UnityEditor;

public class DuelConnObj : MonoBehaviour {
    // Start is called before the first frame update
    public DuelConnector conn;
    public WSConnect2 wsConnect;
    List<System.EventHandler<WebSocketSharp.MessageEventArgs>> wscHandler = new List<System.EventHandler<WebSocketSharp.MessageEventArgs>>();
    public Room current_room;
    // public AsyncDuplexStreamingCall<CellStatusReq, CellStatusResp> stream_status;
    // public AsyncServerStreamingCall<CellStatusResp> get_only_status_stream;
    public bool isBroadcast { get { return is_bc; } }
    bool is_bc = false;
    public bool able_update = false;
    public bool IsHost = false;
    // Temp setting
    public CfServerSetting ConfigFile;
    // Debug Scn
    public DebugTestScript DebugScn;
    public string config_file;
    void Awake() {
        Debug.Log("on Awake process - DuelConnObj");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Connector");
        if (objs.Length > 1) {
            if (this.conn == null) {
                Destroy(this.gameObject);
            }
        } else {
            DontDestroyOnLoad(this.gameObject);
            this.gameObject.tag = "Connector";
            if (this.conn == null) {
                ConfigFile = Config.LoadCfFile(PlayCli.ConfigPath.StreamingAsset).remote;
                this.conn = new DuelConnector(ConfigFile);
            }
        }
    }

    public void Init() {
        if (this.conn == null) {
            ConfigFile = Config.LoadCfFile(PlayCli.ConfigPath.StreamingAsset).remote;
            this.conn = new DuelConnector(ConfigFile);
        }
    }

    public async Task<bool> CreateRoom() {
        Debug.Log("on CreateRoom process - DuelConnObj");
        // open loading 
        try {
            this.current_room = await this.conn.CreateRoom();
            this.able_update = true;
            this.IsHost = true;
            // await this.conn.ConnectToBroadcast();
            return true;
        } catch (RpcException e) {
            Debug.Log(e);
            return false;
            throw;
        }
        // stream_status = this.conn.GetRoomStream (current_room.Key);
    }

    public async Task<bool> JoinRoom(string key, bool is_player) {
        Debug.Log("on JoinRoom process - DuelConnObj");
        try {
            var ri = await this.conn.GetRoomInfo(key);
            Debug.Log(ri);
            current_room = ri.RoomInfo;
            this.able_update = is_player;
            this.IsHost = false;
            if (is_player) {
                await this.conn.UpdateRoomTurn(new CellStatus {
                    Key = key,
                    Turn = 0,
                    CellNum = -21
                });
            }
            // await this.conn.ConnectToBroadcast();
            return true;
        } catch (RpcException e) {
            Debug.Log(e);
            return false;
            throw;
        }
    }

    public async Task<List<Room>> GetRoomList(string para) {
        return await this.conn.GetRoomList(para);
    }

    public async Task<bool> UpdateTurn(CellStatus cs) {
        try {
            if (able_update) {
                CellStatus d = await this.conn.UpdateRoomTurn(cs);
                return true;
            }
            return false;
        } catch (RpcException e) {
            Debug.Log(e);
            return false;
            throw;
        }
    }

    public async Task<bool> ExitRoom() {
        bool status = false;

        if (this.current_room != null) {
            status = await this.conn.QuitRoom();
            this.current_room = null;
        }
        if (this.wsConnect != null) {
            await this.wsConnect.DisconnectToBroadcast();
            this.wsConnect = null;
        }
        return status;
    }

    public async Task<Room> RefreshRoomInfo() {
        if (this.current_room != null) {
            var tt = await this.conn.GetRoomInfo(current_room.Key);
            if (tt.Error == null) {
                this.current_room = tt.RoomInfo;
                return this.current_room;
            }
            // else case:
            return null;
        }
        return null;
    }

    // public async Task<bool> ConnectToBroadcast(
    //     Dictionary<string, string> ConnOption = null,
    //     Dictionary<string, SocketIOClient.EventHandler> EventMap = null
    // ) {
    //     var option = ConnOption == null?
    //     new Dictionary<string, string> { { "uid", this.conn.HostId },
    //             { "test_eng", "Unity" },
    //             { "room_key", this.current_room.Key },
    //         }:
    //         ConnOption;

    //     Debug.Log("try connect to Broacast");
    //     var conn = await this.conn.ConnectToBroadcast(
    //         ConfigFile, option);
    //     if (!conn) {
    //         return false;
    //     }
    //     foreach (KeyValuePair<string, SocketIOClient.EventHandler> kv in EventMap) {
    //         this.conn.AddEventFunc(kv.Key, kv.Value);
    //     }
    //     // StartCoroutine(PingReturn());
    //     await this.conn.RoomBroadcast.EmitAsync("join_room", this.current_room.Key);

    //     return true;
    // }
    public async Task<bool> ConnectToBroadcast() {
        Debug.Log("try connect to Broacast");
        if (this.wsConnect == null) {
            this.wsConnect = new WSConnect2();
        }
        var conn = await this.wsConnect.ConnectToBroadcast(
            this.current_room.Key, ConfigFile, wscHandler);
        if (!conn) {
            return false;
        }
        // await this.conn.RoomBroadcast.EmitAsync("join_room", this.current_room.Key);
        return true;
    }
    ///<method>
    ///     For Socket-IO-Impl 
    /// </method>
    // public bool AddEventFunc(string eventName, EventHandler func, params EventHandler[] extraFunc) {
    //     return this.conn.AddEventFunc(eventName, func, extraFunc);
    // }

    ///<method>
    ///     For WebSocket-Impl 
    /// </method>
    // public bool AddEventFunc(System.Action<Websocket.Client.ResponseMessage> messageEvent) {
    //     this.wsConnect.AddEventFunc(messageEvent);
    //     return true;
    // }

    ///<method>
    ///     For WebSocket-Impl 
    /// </method>
    // public bool AddEventFunc(System.Action<CellStatusResp> func) {
    //     this.wsConnect.AddEventFunc((msg) => {
    //         var MsgBlock = CellStatusResp.Parser.ParseFrom(
    //             ByteString.FromBase64(
    //                 msg.Text.Trim('"')
    //             )
    //         );
    //         func(MsgBlock);
    //     });
    //     return true;
    // }

    ///<method>
    ///     For WebSocket-Impl 2
    /// </method>
    public bool AddEventFunc(System.EventHandler<WebSocketSharp.MessageEventArgs> funcHandler) {
        // if (this.wsConnect != null) {
        //     this.wsConnect.AddEventFunc(funcHandler);
        // }
        this.wscHandler.Add(funcHandler);
        return true;
    }
    public bool AddEventFunc(System.EventHandler<CellStatusResp> funcHandler) {
        var wrapFunc = new System.EventHandler<WebSocketSharp.MessageEventArgs>((co, msg) => {
            Debug.Log($"sender:{co.ToString()}");
            Debug.Log($"Msg :{msg.Type.ToString()}");
            var msgBlock = CellStatusResp.Parser.ParseFrom(
                msg.RawData
            );
            funcHandler(co, msgBlock);
        });
        // if (this.wsConnect != null) {
        //     return this.wsConnect.AddEventFunc(wrapFunc);
        // }
        this.wscHandler.Add(wrapFunc);
        return true;
    }

    public async Task<bool> DisconnectToBroadcast() {
        return await this.wsConnect.DisconnectToBroadcast();
    }

    void Destroy() {
        this.DisconnectToBroadcast();
    }
}