using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocketIOClient;
using UnityEngine;

namespace PlayCli {
    public class SkioConnector {
        public SocketIO RoomBroadcast;
        //  --------------------------------------------
        // Socket-IO

        public async Task<bool> ConnectToBroadcast(CfServerSetting conf = null, Dictionary<string, string> option = null) {
            var opt = option == null ?
                new Dictionary<string, string> { 
                    { "uid", conf.Username},
                    { "testEng", "Unity" },
                } :
                option;

            var socket = new SocketIO($"http://{conf.Host}:8000") {
                Parameters = opt
            };

            socket.OnConnected += () => {
                Debug.Log("Connected");
            };

            socket.OnError += (res) => {
                Debug.LogError(res);
            };

            await socket.ConnectAsync();
            this.RoomBroadcast = socket;
            return true;
        }

        public bool AddEventFunc(string eventName, SocketIOClient.EventHandler func, params SocketIOClient.EventHandler[] extraFunc) {

            if (this.RoomBroadcast != null) {
                this.RoomBroadcast.On(eventName, func, extraFunc);
                return true;
            }
            return false;
        }

        public async Task<bool> DisconnectToBroadcast() {
            if (this.RoomBroadcast != null) {
                await this.RoomBroadcast.CloseAsync();
            }
            return true;
        }
    }
}