using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceRepeatFactory
{    
    SimonButton[] simonButtons;
    bool isRepeat;

    public GameSequenceRepeatFactory(SimonButton[] simonButtons, bool isRepeat)
    {
        this.simonButtons = simonButtons;
        this.isRepeat = isRepeat;        
    }
    public IGameSequenceRepeat GetGameSequenceRepeat(GameObject _GameObject, GameSequence gameSequence)
    {
        IGameSequenceRepeat gameRepeat;
        if (isRepeat)
            gameRepeat = _GameObject.AddComponent<GameSequenceReapetAll>();
        else
            gameRepeat = _GameObject.AddComponent<GameSequenceReapetLast>();        
        gameRepeat.simonButtons = this.simonButtons;
        gameRepeat._GameSequence = gameSequence;
        return gameRepeat;
    }
}
