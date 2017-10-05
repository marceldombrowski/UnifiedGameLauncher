using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedGameLauncher
{
    public static class RenamingHashtable
    {
        public static Dictionary<string, string> MyHashset;
        private static bool Initialized = false;

        private static void Initialize()
        {
            if (File.Exists("naming.json"))
            {
                MyHashset = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("naming.json"));
            } else
            {
                MyHashset = new Dictionary<string, string>();
            }
            Initialized = true;
        }

        public static string GetNiceName(string name)
        {
            if (!Initialized)
            {
                Initialize();
            }

            string outname = "";
            if (MyHashset.TryGetValue(name, out outname))
            {
                return outname;
            }
            return "UNDEFINED";
        }

        public static void AddEntry(string shortName, string longName)
        {
            if (!Initialized)
            {
                Initialize();
            }

            if (!MyHashset.ContainsKey(shortName))
            {
                MyHashset.Add(shortName, longName);
            }
        }

        public static void RemoveEntry(string shortName)
        {
            if (!Initialized)
            {
                Initialize();
            }

            MyHashset.Remove(shortName);
        }

        public static void SaveHashtable()
        {
            if (!Initialized)
            {
                Initialize();
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("naming.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, MyHashset);
            }
        }
    }
}
