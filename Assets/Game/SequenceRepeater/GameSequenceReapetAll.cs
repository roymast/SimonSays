using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceReapetAll : IGameSequenceRepeat
{
    public GameSequenceReapetAll(SimonButton[] simonButtons) : base(simonButtons)
    {
    }
    public override IEnumerator RepeatSequence(List<int> buttonsSequence)
    {
        yield return new WaitForSeconds(1);
        foreach (int buttonIndex in buttonsSequence)
        {
            simonButtons[buttonIndex].ClickAnimationAndSound();
            yield return new WaitForSeconds(0.5f);
        }        
    }    
}
