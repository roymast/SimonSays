using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeaderboardData
{
    const string LeaderboardKey = "LeaderBoard";
    [System.Serializable]
    public class LeaderboardEntryData
    {
        public string Name;
        public int Score;
        public LeaderboardEntryData(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public string ToString()
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
        LeaderboardEntryData[] leaderboardArray = new LeaderboardEntryData[leaderboard.Count];
        int i = 0;
        foreach (var item in leaderboard.Values)
        {
            leaderboardArray[i] = item;
            i++;
        }
        leaderboardArray.OrderBy(item => item.Score);
        leaderboardArray.Reverse();
        return leaderboardArray;
    }
}
