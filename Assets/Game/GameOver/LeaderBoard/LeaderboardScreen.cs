using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderboardScreen : MonoBehaviour
{
    LeaderboardData LeaderboardData;
    [SerializeField] LeaderboardLine LeaderboardLinePrefab;
    [SerializeField] Transform LeaderboardContainer;
    LeaderboardData.LeaderboardEntryData[] leaderBoardData;
    LeaderboardLine[] leaderboardLines;

    // Start is called before the first frame update
    void Start()
    {
        LeaderboardData = new LeaderboardData();
        leaderBoardData = LeaderboardData.ReadFromLeaderboard();
        leaderboardLines = CreateAllLeaderboardLines(leaderBoardData);
    }
    LeaderboardLine[] CreateAllLeaderboardLines(LeaderboardData.LeaderboardEntryData[] leaderBoard)
    {
        leaderboardLines = new LeaderboardLine[leaderBoard.Length];
        for (int i = 0; i < leaderBoard.Length; i++)
            leaderboardLines[i] = InstantiateNewLeaderboardLine(leaderBoard[i]);

        return leaderboardLines;
    }
    LeaderboardLine InstantiateNewLeaderboardLine(LeaderboardData.LeaderboardEntryData leaderboardEntryData)
    {
        LeaderboardLine newLeaderboardLine = Instantiate(LeaderboardLinePrefab, LeaderboardContainer);
        newLeaderboardLine.Name.text = leaderboardEntryData.Name;
        newLeaderboardLine.Score.text = leaderboardEntryData.Score.ToString();
        return newLeaderboardLine;
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
