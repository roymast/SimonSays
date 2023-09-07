using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Configurations.GameConfigurations;

/// <summary>
/// GameManager is managing the flow of the game
/// </summary>
public class GameManager : SingletonBehaviour<GameManager>
{
    public Action OnGameOver;    
    [SerializeField] PointsManager PointsManager;
    [SerializeField] GameSequence GameSequence;    
    [SerializeField] GameTimer GameTimer;
    [SerializeField] GameOverScreen GameOverScreen;
    [SerializeField] SimonButtonFactory SimonButtonFactory;
    
    public ModeConfig currentConfig { get { return ModeManager.Instance.ModeConfigs; }}
    SimonButton[] buttons;
    public SimonButton[] Buttons
    {
        get
        {
            if (buttons == null || buttons.Length == 0)
                buttons = CreateButtons(GetButtonsAmount);
            return buttons;
        }
    }
    public int GetButtonsAmount { get { return currentConfig.GameButtons; } }
    public IGameSequenceRepeat gameSequenceRepeat;
    public IGameSequenceRepeat GameSequenceRepeat
    {
        get
        {
            if (gameSequenceRepeat != null)
                return gameSequenceRepeat;
            else
            {
                GameObject gameRepeat = Instantiate(new GameObject());
                gameSequenceRepeat = new GameSequenceRepeatFactory(Buttons, currentConfig.RepeatMode).GetGameSequenceRepeat(gameRepeat, GameSequence);
                gameRepeat.name = gameSequenceRepeat.GetType().Name;
                return gameSequenceRepeat;
            }
        }
        private set { gameSequenceRepeat = value; }
    }
    public string playerName { get { return ModeManager.PlayerName; }}
    
    // Start is called before the first frame update
    protected void Start()
    {        
        GameTimer.OnTimeUp += OnTimeUp;
        GameSequence.OnWrongSequence += OnWrongSequence;
        GameSequence.OnSequenceFinished += OnSequenceFinished;                
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
        OnGameOver?.Invoke();
        GameSequence.OnSequenceFinished -= OnSequenceFinished;
        GameSequenceRepeat.OnSequenceRepeatFinished -= OnSequenceRepeatFinished;
        GameOverScreen.SetPlayerData(playerName, PointsManager.pointsValue, false);
        GameOverScreen.EnterState();       
    }

    private void OnTimeUp()
    {
        OnGameOver?.Invoke();
        GameSequence.OnSequenceFinished -= OnSequenceFinished;
        GameSequenceRepeat.OnSequenceRepeatFinished -= OnSequenceRepeatFinished;
        GameOverScreen.SetPlayerData(playerName, PointsManager.pointsValue, true);
        GameOverScreen.EnterState();
    }
    SimonButton[] CreateButtons(int amount)
    {
        SimonButton[] buttons = new SimonButton[amount];
        for (int i = 0; i < amount; i++)
            buttons[i] = SimonButtonFactory.GetSimonButtonByIndex(i);

        return buttons;
    }
}
