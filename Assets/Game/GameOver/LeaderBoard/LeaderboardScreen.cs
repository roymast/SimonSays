using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderboardScreen : MonoBehaviour
{
    LeaderboardData LeaderboardData;
    [SerializeField] LeaderboardLine LeaderboardLinePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        LeaderboardData = new LeaderboardData();
        LeaderboardData.WriteToLeaderboard("roy1", 100);
        LeaderboardData.WriteToLeaderboard("roy2", 35);
        LeaderboardData.WriteToLeaderboard("roy3", 5);
        LeaderboardData.WriteToLeaderboard("roy4", 600);
        PrintLeaderBoard(LeaderboardData.ReadFromLeaderboard());

    }    
    void PrintLeaderBoard(LeaderboardData.LeaderboardEntryData[] orderedEnumerable)
    {
        string s = "";
        foreach (var item in orderedEnumerable)
        {
            s += item.ToString();
            s += "\n";
        }
        Debug.Log(s);
    }
}
