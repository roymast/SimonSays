using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceReapetLast : IGameSequenceRepeat
{
    public GameSequenceReapetLast(SimonButton[] simonButtons) : base(simonButtons)
    {
    }

    public override IEnumerator RepeatSequence(List<int> buttonSequence)
    {
        yield return new WaitForSeconds(1);
        simonButtons[buttonSequence[buttonSequence.Count-1]].ClickAnimationAndSound();
    }    
}
