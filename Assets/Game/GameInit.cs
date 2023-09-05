using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInit : SingletonBehaviour<GameInit>
{
    [SerializeField] SimonButtonFactory SimonButtonFactory;
    public SimonButton[] buttons;
    public PointsManager PointsManager;
    public GameTimer GameTimer;
    GameSequenceRepeatFactory GameSequenceRepeatFactory;
    public IGameSequenceRepeat gameSequenceRepeat;
    public GameSequence GameSequence;
    public int GetButtonsAmount { get { return buttons.Length; } }

    void Awake()
    {
        CreateButtons(ModeManager.ModeConfigs.GameButtons);
        PointsManager.defaultPointsToAdd = ModeManager.ModeConfigs.PointEachStep;
        GameTimer.totalTime = ModeManager.ModeConfigs.GameTime;
        GameSequenceRepeatFactory = new GameSequenceRepeatFactory(buttons, ModeManager.ModeConfigs.RepeatMode, GameSequence);
        gameSequenceRepeat = GameSequenceRepeatFactory.GetGameSequenceRepeat(gameObject);
        
    }
    SimonButton[] CreateButtons(int amount)
    {
        buttons = new SimonButton[amount];
        for (int i = 0; i < amount; i++)
            buttons[i] = SimonButtonFactory.GetSimonButtonByIndex(i);

        return buttons;
    }
}
