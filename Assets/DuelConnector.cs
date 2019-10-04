using System.Collections;
using System.Collections.Generic;
using Grpc.Core;
using PlayCli.ProtoMod;
using UnityEngine;
namespace PlayCli {
    public class GameCtl {
        readonly PlayCli.GameCtl client;

        public GameCtl (GameCtl client) {
            this.client = client;
        }

        public bool CreateRoom(){
            return true;
        }
    }
}