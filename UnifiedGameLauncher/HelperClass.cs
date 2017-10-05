using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

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

        public HelperClass()
        {
            MyGames = new List<GameEntry>();
            LoadJson();
        }

        public void ImportFromSteam()
        {

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
