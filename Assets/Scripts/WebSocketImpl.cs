using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

using Websocket.Client;

namespace PlayCli {
    public class WSConnect {
        public WebsocketClient RoomCast;
        //  --------------------------------------------
        // Socket-IO
        private static readonly ManualResetEvent ExitEvent = new ManualResetEvent(false);

        public async Task<bool> ConnectToBroadcast(string RoomKey, CfServerSetting conf = null) {
            // ExitEvent.Reset();
            var factory = new Func<ClientWebSocket>(() => {
                var client = new ClientWebSocket {
                Options = {
                KeepAliveInterval = TimeSpan.FromSeconds(5),
                }
                };
                //client.Options.SetRequestHeader("Origin", "xxx");
                return client;
            });
            var url = new Uri($"ws://{conf.Host}:8000/{RoomKey}");

            var wsclient = new WebsocketClient(url, factory);
            wsclient.ReconnectTimeout = TimeSpan.FromSeconds(30);
            wsclient.ErrorReconnectTimeout = TimeSpan.FromSeconds(30);
            wsclient.ReconnectionHappened.Subscribe(type => {
                Debug.Log($"Reconnection happened, type: {type}, url: {wsclient.Url}");
            });
            wsclient.DisconnectionHappened.Subscribe(info => {
                Debug.LogWarning($"Disconnection happened, type: {info.Type}");
                Debug.LogWarning(info.CloseStatusDescription);
                Debug.LogWarning(info.Exception.ToString());
            });

            wsclient.MessageReceived.Subscribe(msg => {
                Debug.Log($"Message received: {msg}");
            });

            await wsclient.Start();
            this.RoomCast = wsclient;

            // ExitEvent.WaitOne();
            return true;

        }
        public bool AddEventFunc(Action<Websocket.Client.ResponseMessage> func) {
            if (this.RoomCast != null) {
                this.RoomCast.MessageReceived.Subscribe(func);
                return true;
            }
            return false;
        }

        public async Task<bool> DisconnectToBroadcast() {
            if (this.RoomCast != null) {
                ExitEvent.Set();
                await this.RoomCast.Stop(WebSocketCloseStatus.NormalClosure, "endOfCast");
            }
            return true;
        }
    }
}