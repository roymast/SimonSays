using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameSequenceRepeat
{
    public Action OnSequenceRepeatFinished;
    protected SimonButton[] simonButtons;    

    public IGameSequenceRepeat(SimonButton[] simonButtons)
    {
        this.simonButtons = simonButtons;
    }    
    public abstract IEnumerator RepeatSequence(List<int> buttonsSequence);    
}
