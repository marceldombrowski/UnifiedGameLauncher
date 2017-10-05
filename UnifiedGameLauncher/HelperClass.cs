using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace UnifiedGameLauncher
{
    public class GameEntry
    {
        public GameEntry(int id, string name, string args, string image)
        {
            GameId = id;
            GameName = name;
            GameImage = image;
            GameArgs = args;
        }

        public GameEntry()
        {

        }

        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameImage { get; set; }
        public string GameArgs { get; set; }
    }

    public class HelperClass
    {
        private List<GameEntry> MyGames;
        private int NextId = 0;

        public delegate void CallbackEventHandler();
        public event CallbackEventHandler Callback;

        public HelperClass()
        {
            MyGames = new List<GameEntry>();
            LoadJson();
        }

        public void ImportFromSteam(string directory)
        {
            List<string> directories = new List<string>();
            if (!File.Exists(directory + "\\steamapps\\libraryfolders.vdf"))
            {
                MessageBox.Show("This directory does not contain your main Steam folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string text = File.ReadAllText(directory + "\\steamapps\\libraryfolders.vdf");
            int i = 1;

            directories.Add(directory + "\\steamapps\\common");

            while (text.Contains("\"" + i + "\"")) {
                int t = text.IndexOf("\"" + i + "\"") + ("\"" + i + "\"").Length + 3;
                int t2 = text.IndexOf('\n', t) - 1;
                directories.Add(text.Substring(t, t2 - t) + "\\steamapps\\common");
                i++;
            }

            i = 0;
            foreach(string dir in directories)
            {
                foreach (string subdir in Directory.GetDirectories(dir))
                {
                    foreach(string exe in Directory.GetFiles(subdir, "*.exe")) {
                        string[] mySplitString = exe.Split('\\');
                        string myString = mySplitString[mySplitString.Length - 1];
                        string myName = myString.Substring(0, myString.Length - 4);
                        MyGames.Add(new GameEntry(GetNextId(), myName, exe, exe));
                    }
                }
            }
            
            if (Callback != null)
            {
                Callback();
            }
        }

        public void ImportFromOrigin()
        {

        }

        public void ImportFromBattleNet()
        {

        }

        public void ImportFromGogGalaxy()
        {

        }

        public void ImportFromUPlay()
        {

        }

        public List<GameEntry> GetList()
        {
            return MyGames;
        }

        public void RemoveEntry(int id)
        {
            MyGames.RemoveAt(id);
        }

        public string GetExecutable(int id)
        {
            return MyGames[id].GameArgs;
        }

        public int GetNextId()
        {
            return NextId++;
        }

        public void AddEntry(GameEntry MyEntry)
        {
            MyGames.Add(MyEntry);
        }

        private void LoadJson()
        {
            if (File.Exists("gameList.json"))
            {
                MyGames = JsonConvert.DeserializeObject<List<GameEntry>>(File.ReadAllText("gameList.json"));
            }
        }

        public void SaveAsJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            using(StreamWriter sw = new StreamWriter("gameList.json"))
            using(JsonWriter writer = new JsonTextWriter(sw))
            { 
                serializer.Serialize(writer, MyGames);
            }
        }
    }
}
