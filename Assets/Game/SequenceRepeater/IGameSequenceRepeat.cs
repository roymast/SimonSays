using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameSequenceRepeat : GameState
{
    public Action OnSequenceRepeatFinished;
    public SimonButton[] simonButtons;    
    public GameSequence _GameSequence;    
                            
    public abstract IEnumerator RepeatSequence(LinkedList<int> buttonsSequence);

    public override void EnterState()
    {
        StartCoroutine(RepeatSequence(_GameSequence.buttonsSequence));
    }

    public override void UpdateState()
    {        
    }

    public override void ExitState()
    {
        OnSequenceRepeatFinished?.Invoke();
    }
}
