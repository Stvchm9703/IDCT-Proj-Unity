using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Grpc.Core;
using PlayCli;
using PlayCli.ProtoMod;
using UnityEngine;
public class AC_CertConn : MonoBehaviour {
    public CfServerSetting ConfigForm;

    private Channel auth_chan, main_room_chan;
    private RoomStatus.RoomStatusClient test_cli;
    private CreditsAuth.CreditsAuthClient create_auth_cli;
    private string file;

    public bool TryConnectAuthServ(string ip_address, int port) {
        try {
            this.auth_chan = new Channel(
                ip_address, port, ChannelCredentials.Insecure
            );
            this.create_auth_cli = new CreditsAuth.CreditsAuthClient(this.auth_chan);

            ConfigForm.Connector = "grpc";
            ConfigForm.Host = ip_address;
            ConfigForm.Port = port;
            return true;
        } catch (RpcException e) {
            Debug.LogError(e);
            return false;
            throw;
        }
    }

    public async Task<bool> CreateAccount(string username, string password) {
        if (this.create_auth_cli == null) {
            return false;
        }

        try {
            var req = new CredReq {
                Ip = GetLocalIPAddress(),
                Username = username,
                Password = password,
            };
            CreateCredResp result = await this.create_auth_cli.CreateCredAsync(req);
            Debug.Log(result);
            if (result.Code != 200) {
                return false;
            }
            file = result.File.ToStringUtf8();
            return true;

        } catch (RpcException e) {
            Debug.LogError(e);
            return false;
            throw;
        }
    }
    public async Task<bool> TryLogin(string username, string password) {
        if (this.create_auth_cli == null) {
            return false;
        }
        try {
            var req = new CredReq {
                Ip = GetLocalIPAddress(),
                Username = username,
                Password = password,
            };
            CheckCredResp result = await this.create_auth_cli.CheckCredAsync(req);
            if (result.ErrorMsg != null) {
                Debug.Log(result.ErrorMsg);
                return false;
            }
            ConfigForm.Username = username;
            ConfigForm.Password = password;
            return true;
        } catch (RpcException e) {
            Debug.LogError(e);
            return false;
            throw;
        }
    }
  

    public async Task<bool> TryConnectMain(string ip_address, int port) {
        try {
            var crt = new SslCredentials(File.ReadAllText(ConfigForm.KeyPemPath));
            this.main_room_chan = new Channel(
                ip_address, port, crt
            );
            this.test_cli = new RoomStatus.RoomStatusClient(this.main_room_chan);

            // test run 
            Debug.Log("test run");
            var d = await this.test_cli.GetRoomListAsync(new RoomListReq {
                Requirement = "",
            });

            if (d.ErrorMsg != null) {
                Debug.LogError(d.ErrorMsg);
                return false;
            }
            if (ConfigForm.Connector == "") {
                ConfigForm.Connector = "grpc";
            }
            if (ConfigForm.Host == "") {
                ConfigForm.Host = ip_address;
            }
            if (ConfigForm.Port == 0) {
                ConfigForm.Port = port;
            }
            return true;

        } catch (RpcException e) {
            Debug.LogError(e);
            return false;
            throw e;
        }

    }

    public static string GetLocalIPAddress() {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList) {
            if (ip.AddressFamily == AddressFamily.InterNetwork) {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }

    public void SaveAsset() {
        ConfigForm.KeyPemPath = "%StreamAsset%/" + "key.pem";
        Config.CreateCfFile(Application.streamingAssetsPath, ConfigForm);
        string[] tpath = {
            Application.streamingAssetsPath,
            "key.pem"
        };
        if (!File.Exists(Path.Combine(tpath))) {
            File.CreateText(Path.Combine(tpath));
        }
        using(StreamWriter filestm =
            new StreamWriter(Path.Combine(tpath))) {
            filestm.WriteLine(file);
        }
        return;
    }
 
    void Destory() {
        if (test_cli != null) {
            this.test_cli = null;
            this.main_room_chan.ShutdownAsync().Wait();
        }
        if (create_auth_cli != null) {
            this.create_auth_cli = null;
            this.auth_chan.ShutdownAsync().Wait();
        }

    }
}