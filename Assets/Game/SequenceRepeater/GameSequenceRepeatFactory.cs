using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceRepeatFactory
{
    GameSequence GameSequence;
    SimonButton[] simonButtons;
    bool isRepeat;


    public GameSequenceRepeatFactory(SimonButton[] simonButtons, bool isRepeat, GameSequence gameSequence)
    {
        this.simonButtons = simonButtons;
        this.isRepeat = isRepeat;
        this.GameSequence = gameSequence;
    }
    public IGameSequenceRepeat GetGameSequenceRepeat(GameObject _GameObject)
    {
        IGameSequenceRepeat gameRepeat;
        if (isRepeat)
            gameRepeat = _GameObject.AddComponent<GameSequenceReapetAll>();
        else
            gameRepeat = _GameObject.AddComponent<GameSequenceReapetLast>();
        gameRepeat._GameSequence = this.GameSequence;
        gameRepeat.simonButtons = this.simonButtons;
        return gameRepeat;
    }
}
