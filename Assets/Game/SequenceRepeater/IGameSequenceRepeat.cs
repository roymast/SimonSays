using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameSequenceRepeat : MonoBehaviour
{
    public Action OnSequenceRepeatFinished;
    public SimonButton[] simonButtons;

    public GameInit gameInit;
    private void Start()
    {
        simonButtons = gameInit.GetButtons();
    }
    public abstract IEnumerator RepeatSequence(List<int> buttonsSequence);    
}
