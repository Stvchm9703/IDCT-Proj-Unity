using System;
using System.IO;
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
            if (File.Exists(r)) {
                try {
                    using(var reader = new StreamReader(work_dir)) {
                        var yaml = new YamlStream();
                        yaml.Load(reader);
                        Debug.Log(yaml);
                        var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
                    }
                } catch (Exception e) {
                    Debug.Log(e);
                }
            }
            return t;

        }

        public static bool CreateCfFile(string out_dir, CfServerSetting setting) {

            // var lin = Helper;
            string[] tpath = {
                out_dir,
                "config.yaml"
            };
            if (!File.Exists(Path.Combine(tpath))) {
                File.CreateText(Path.Combine(tpath));
            }
        
            using(StreamWriter file = new System.IO.StreamWriter(Path.Combine(tpath))) {
                var serializer = new SerializerBuilder().Build();
                serializer.Serialize(file, setting);
            }

            // File.AppendAllText(Path.Combine(tpath), yml);
            return true;
        }
    }
}