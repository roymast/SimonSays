using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Leaderboard
{
    /// <summary>
    /// LeaderboardData is designed to read and write to the leaderboard    
    /// </summary>
    public partial class LeaderboardData
    {
        //The leaderboard should either contain only limited amount of players or be saved in database
        //That is because the leaderboard is saved in the PlayerPrefs as a json
        //and when readed, the data is getting sorted. Right now there is no problem with that, but there will when the leaderboard will increase

        const string LeaderboardKey = "LeaderBoard";
        public void WriteToLeaderboard(string playerName, int playerPoints)
        {
            if (string.IsNullOrEmpty(playerName))   //should not happen, but just in case
                return;

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
