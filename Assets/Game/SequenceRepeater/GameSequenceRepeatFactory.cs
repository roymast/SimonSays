using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceRepeatFactory
{
    [SerializeField] SimonButton[] simonButtons;
    [SerializeField] bool isRepeat;
    public GameSequenceRepeatFactory(SimonButton[] simonButtons, bool isRepeat)
    {
        this.simonButtons = simonButtons;
        this.isRepeat = isRepeat;
    }
    public IGameSequenceRepeat GetGameSequenceRepeat()
    {        
        if (isRepeat)
            return new GameSequenceReapetAll(simonButtons);
        else
            return new GameSequenceReapetLast(simonButtons);
    }
}
