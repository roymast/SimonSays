using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] GameInit GameInit;
    [SerializeField] PointsManager PointsManager;
    [SerializeField] GameSequence GameSequence;
    [SerializeField] IGameSequenceRepeat GameSequenceRepeat;
    [SerializeField] GameTimer GameTimer;
    [SerializeField] GameOverScreen GameOverScreen;
    public string playerName { get; private set; }        
    
    // Start is called before the first frame update
    void Start()
    {
        playerName = "testing";
        GameTimer.OnTimeUp += OnTimeUp;
        GameSequence.OnWrongSequence += OnWrongSequence;
        GameSequence.OnSequenceFinished += OnSequenceFinished;        
        GameSequenceRepeat = GameInit.gameSequenceRepeat;
        GameSequenceRepeat.OnSequenceRepeatFinished += OnSequenceRepeatFinished;
        GameSequenceRepeat.EnterState();        
    }
    void OnSequenceFinished()
    {
        GameSequenceRepeat.EnterState();        
    }
    void OnSequenceRepeatFinished()
    {
        GameSequence.EnterState();
    }
    private void OnWrongSequence()
    {
        GameSequence.OnSequenceFinished -= OnSequenceFinished;
        GameSequenceRepeat.OnSequenceRepeatFinished -= OnSequenceRepeatFinished;
        GameTimer.enabled = false;
        GameOverScreen.InsertCurrentPlayerScore(playerName, PointsManager.pointsValue);
        GameOverScreen.EnterState();       
    }

    private void OnTimeUp()
    {
        GameSequence.OnSequenceFinished -= OnSequenceFinished;
        GameSequenceRepeat.OnSequenceRepeatFinished -= OnSequenceRepeatFinished;
        GameOverScreen.EnterState();
    }
}
