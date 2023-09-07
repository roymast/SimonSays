using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Configurations.GameConfigurations;

public class GameInit : SingletonBehaviour<GameInit>
{    
    [SerializeField] SimonButtonFactory SimonButtonFactory;
    [SerializeField] GameSequence GameSequence;
    ModeManager modeManager;
    public ModeConfig currentConfig { get; private set; }
    public SimonButton[] buttons { get; private set; }        
    public int GetButtonsAmount { get { return buttons.Length; } }
    public IGameSequenceRepeat gameSequenceRepeat;
    public IGameSequenceRepeat GameSequenceRepeat 
    {
        get 
        {
            if (gameSequenceRepeat != null)
                return gameSequenceRepeat;
            else
            {                
                gameSequenceRepeat = new GameSequenceRepeatFactory(buttons, currentConfig.RepeatMode).GetGameSequenceRepeat(gameObject, GameSequence);
                return gameSequenceRepeat;
            }
        }
        private set { gameSequenceRepeat = value; }
    }
    private void Start()
    {
        Debug.Log("Start Game Init");
    }
    protected override void Awake()
    {
        Debug.Log("Awake Game Init");
        base.Awake();
        InitData();
    }
    public void InitData()
    {        
        modeManager = ModeManager.Instance;
        currentConfig = modeManager.ModeConfigs;
        buttons = CreateButtons(currentConfig.GameButtons);
    }
    SimonButton[] CreateButtons(int amount)
    {
        SimonButton[] buttons = new SimonButton[amount];
        for (int i = 0; i < amount; i++)
            buttons[i] = SimonButtonFactory.GetSimonButtonByIndex(i);

        return buttons;
    }
}
