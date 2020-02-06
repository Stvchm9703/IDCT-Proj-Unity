using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PlayCli {
    [System.Serializable]
    public class ConfigTempContainer {
        public string work_dir_path;
        public CfServerSetting remote;
    }

    [System.Serializable]
    public class CfServerSetting {
        public string Connector;
        public string Host;
        public int Port;
        public string Database;
        public string Username;
        public string Password;
        public string Key;

        public string KeyPemPath;
    }

    public static class Config {
        public static ConfigTempContainer LoadCfFile(string work_dir) {
            var t = new ConfigTempContainer();
            t.work_dir_path = work_dir;
            string[] tpath = {
                work_dir,
                "config.yaml"
            };
            var r = Path.Combine(tpath);
            Debug.Log(r);
            if (File.Exists(r)) {
                try {
                    using(StreamReader reader = new StreamReader(r)) {
                        var deserializer = new DeserializerBuilder()
                            .Build();

                        t.remote = deserializer.Deserialize<CfServerSetting>(reader);
                    }
                } catch (Exception e) {
                    Debug.Log(e);
                }
            }
            return t;

        }

        public static async Task<bool> CreateCfFile(string out_dir, CfServerSetting setting) {

            // var lin = Helper;
            var serializer = new SerializerBuilder().Build();
            var yml = serializer.Serialize(setting);
            string[] tpath = { out_dir, "config.yaml" };

            // if (!File.Exists(Path.Combine(tpath))) {
            //     File.WriteAllText(Path.Combine(tpath), yml);
            // } else {
            //     File.AppendAllText(Path.Combine(tpath), yml);
            // }

            using(var sw = new StreamWriter(Path.Combine(tpath))) {
                await sw.WriteAsync(yml);
            }
            // File.AppendAllText(Path.Combine(tpath), yml);
            return true;
        }
    }
}