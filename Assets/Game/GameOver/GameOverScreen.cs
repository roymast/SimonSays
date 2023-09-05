using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : GameState
{
    [SerializeField] Canvas GameOverCanvas;    
    [SerializeField] TextMeshProUGUI WinLoseText;    
    [SerializeField] LeaderboardScreen leaderboard;
    string _playerName;
    private void Start()
    {
        GameOverCanvas.gameObject.SetActive(false);        
    }
    public void ReturnHome()
    {
        SceneManager.LoadScene("StartScreen");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    void InsertCurrentPlayerScore(string playerName, int playerScore)
    {
        leaderboard.InsertNewPlayerScore(playerName, playerScore);        
    }
    public void SetPlayerData(string playerName, int playerScore, bool isWon)
    {
        _playerName = playerName;
        if (isWon)
        {
            WinLoseText.text = "You Won!";
            WinLoseText.color = Color.green;
            InsertCurrentPlayerScore(playerName, playerScore);
        }
        else
        {
            WinLoseText.text = "You Lost!";
            WinLoseText.color = Color.red;
        }
    }    

    public override void EnterState()
    {
        GameOverCanvas.gameObject.SetActive(true);             
        leaderboard.DisplayLeaderboard();
        leaderboard.HighlightPlayer(_playerName);
    }

    public override void ExitState()
    {
        leaderboard.HideLeaderboard();
        GameOverCanvas.gameObject.SetActive(false);
    }    
    
}
