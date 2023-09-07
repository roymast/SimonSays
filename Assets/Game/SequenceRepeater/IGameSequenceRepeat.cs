using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameSequenceRepeat : GameState
{
    protected float WaitTimeBeforeRepeat = 1;
    protected float WaitTimeBetweenRepeat = 0.5f;

    public Action OnSequenceRepeatFinished;
    public SimonButton[] simonButtons;    
    public GameSequence _GameSequence;    
                            
    public abstract IEnumerator RepeatSequence(LinkedList<int> buttonsSequence);    
    public override void EnterState()
    {
        StartCoroutine(RepeatSequence(_GameSequence.buttonsSequence));
    }    

    public override void ExitState()
    {
        OnSequenceRepeatFinished?.Invoke();
    }
}
