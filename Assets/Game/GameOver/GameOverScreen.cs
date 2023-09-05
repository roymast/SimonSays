using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverScreen : GameState
{
    [SerializeField] Canvas GameOverCanvas;    
    [SerializeField] TextMeshProUGUI WinLoseText;    
    [SerializeField] LeaderboardScreen leaderboard;
    private void Start()
    {
        GameOverCanvas.gameObject.SetActive(false);        
    }
    public void InsertCurrentPlayerScore(string playerName, int playerScore)
    {
        leaderboard.InsertNewPlayerScore(playerName, playerScore);
    }

    public override void EnterState()
    {
        GameOverCanvas.gameObject.SetActive(true);
        WinLoseText.text = "Game Over";        
        leaderboard.DisplayLeaderboard();        
    }

    public override void ExitState()
    {
        leaderboard.HideLeaderboard();
        GameOverCanvas.gameObject.SetActive(false);
    }

    public override void UpdateState()
    {
        
    }
    
}
