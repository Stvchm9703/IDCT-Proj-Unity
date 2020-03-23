using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using WebSocketSharp;

namespace PlayCli {
    public class WSConnect2 {
        public WebSocket RoomCast;
        //  --------------------------------------------
        // Socket-IO
        private static readonly ManualResetEvent ExitEvent = new ManualResetEvent(false);

        public async Task<bool> ConnectToBroadcast(string RoomKey, CfServerSetting conf = null) {
            var wsclient = new WebSocket($"ws://{conf.Host}:8000/{RoomKey}");
            wsclient.OnOpen += (type, e) => {
                Debug.Log($"Reconnection happened, type: {type}, url: {wsclient.Url}");
            };
            wsclient.OnError += (info, e) => {
                Debug.LogWarning(info.ToString());
                Debug.LogWarning(e);
            };

            wsclient.OnMessage += (msg, e) => {
                Debug.Log($"Message received: {msg}");
                Debug.Log($"Message : {e.Data}");
            };

            wsclient.ConnectAsync();
            this.RoomCast = wsclient;
            // ExitEvent.WaitOne();
            this.RoomCast.Ping();
            return true;

        }
        public bool AddEventFunc(System.EventHandler<WebSocketSharp.MessageEventArgs> func) {
            if (this.RoomCast != null && this.RoomCast.IsAlive) {
                this.RoomCast.OnMessage += (func);
                return true;
            }
            return false;
        }

        public async Task<bool> DisconnectToBroadcast() {
            if (this.RoomCast != null) {
                this.RoomCast.CloseAsync();
            }
            return true;
        }
    }
}