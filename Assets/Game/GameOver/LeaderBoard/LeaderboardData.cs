using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Leaderboard
{
    public class LeaderboardData
    {
        const string LeaderboardKey = "LeaderBoard";
        [System.Serializable]
        public class LeaderboardEntryData : IComparer
        {
            public string Name;
            public int Score;
            public LeaderboardEntryData(string name, int score)
            {
                Name = name;
                Score = score;
            }

            public int Compare(object x, object y)
            {
                return (new CaseInsensitiveComparer()).Compare(((LeaderboardEntryData)x).Score,
               ((LeaderboardEntryData)y).Score);
            }

            public override string ToString()
            {
                return $"Name: {Name} Score: {Score}";
            }
        }
        public void WriteToLeaderboard(string playerName, int playerPoints)
        {

            Dictionary<string, LeaderboardEntryData> Base = new Dictionary<string, LeaderboardEntryData>();
            if (!PlayerPrefs.HasKey(LeaderboardKey))
                PlayerPrefs.SetString(LeaderboardKey, JsonConvert.SerializeObject(Base));

            LeaderboardEntryData current = new LeaderboardEntryData(playerName, playerPoints);
            Dictionary<string, LeaderboardEntryData> leaderboard = JsonConvert.DeserializeObject<Dictionary<string, LeaderboardEntryData>>(PlayerPrefs.GetString(LeaderboardKey));
            if (leaderboard.ContainsKey(playerName))
            {
                if (leaderboard[playerName].Score < playerPoints)
                    leaderboard[playerName].Score = playerPoints;
            }
            else
                leaderboard.Add(playerName, current);

            string jsonData = JsonConvert.SerializeObject(leaderboard);
            PlayerPrefs.SetString(LeaderboardKey, jsonData);
            PlayerPrefs.Save();
        }
        public LeaderboardEntryData[] ReadFromLeaderboard()
        {
            Dictionary<string, LeaderboardEntryData> leaderboard = JsonConvert.DeserializeObject<Dictionary<string, LeaderboardEntryData>>(PlayerPrefs.GetString(LeaderboardKey));            
            LeaderboardEntryData[] leaderboardArray = leaderboard.Values.ToArray();            
            Array.Sort(leaderboardArray, (x, y) => y.Score.CompareTo(x.Score));                       
            return leaderboardArray;
        }
    }
}
