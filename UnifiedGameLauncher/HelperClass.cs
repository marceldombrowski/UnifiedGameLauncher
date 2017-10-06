using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Drawing;

namespace UnifiedGameLauncher
{
    public class GameEntry : IComparable<GameEntry>
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

        public int CompareTo(GameEntry gameEntry2)
        {
            // A null value means that this object is greater.
            if (gameEntry2 == null)
                return 1;

            else
                return this.GameName.CompareTo(gameEntry2.GameName);
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

        public void EmptyList()
        {
            MyGames.Clear();
            if (Callback != null)
            {
                Callback();
            }
        }

        public void AddImageToLocalDatabase(string exeName, Image myImage)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\icons"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\icons");
            }

            myImage.Save(AppDomain.CurrentDomain.BaseDirectory + "\\icons\\" + exeName + ".bmp");
        }

        public void ImportFromSteam(string directory)
        {
            List<string> directories = new List<string>();
            if (!File.Exists(directory + "\\steamapps\\libraryfolders.vdf"))
            {
                MessageBox.Show("This directory does not contain your main Steam folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Importing your Steam games. This may take a while. Please press OK to start.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        string exeName = myName;
                        myName = RenamingHashtable.GetNiceName(myName);
                        if (myName.Equals("UNDEFINED"))
                            continue;
                        MyGames.Add(new GameEntry(GetNextId(), myName, exe, exe));
                        AddImageToLocalDatabase(exeName, Icon.ExtractAssociatedIcon(exe).ToBitmap());
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
            MessageBox.Show("Todo", "Todo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ImportFromBattleNet()
        {
            MessageBox.Show("Todo", "Todo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ImportFromGogGalaxy()
        {
            MessageBox.Show("Todo", "Todo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ImportFromUPlay()
        {
            MessageBox.Show("Todo", "Todo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MyGames.Sort();
        }

        private void LoadJson()
        {
            if (File.Exists("gameList.json"))
            {
                MyGames = JsonConvert.DeserializeObject<List<GameEntry>>(File.ReadAllText("gameList.json"));
                MyGames.Sort();
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
