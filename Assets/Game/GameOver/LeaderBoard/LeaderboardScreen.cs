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
    public void InsertNewPlayerScore(string playerName, int playerScore)
    {
        LeaderboardData.WriteToLeaderboard(playerName, playerScore);
    }
    public void DisplayLeaderboard()
    {
        LeaderboardContainer.gameObject.SetActive(true);
        
        leaderBoardData = LeaderboardData.ReadFromLeaderboard();
        leaderboardLines = CreateAllLeaderboardLines(leaderBoardData);
    }
    public void HighlightPlayer(string playerName)
    {
        foreach (LeaderboardLine leaderboardLine in leaderboardLines)
            if (leaderboardLine.Name.text == playerName)
                leaderboardLine.Highligh();
    }    
    
    public void HideLeaderboard()
    {
        LeaderboardContainer.gameObject.SetActive(false);
    }    

    // Start is called before the first frame update
    void Start()
    {        
        LeaderboardData = new LeaderboardData();
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
