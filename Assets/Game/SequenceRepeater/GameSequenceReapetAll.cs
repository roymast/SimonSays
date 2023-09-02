using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceReapetAll : IGameSequenceRepeat
{
    public override IEnumerator RepeatSequence(List<int> buttonsSequence)
    {
        yield return new WaitForSeconds(1);
        foreach (int buttonIndex in buttonsSequence)
        {
            simonButtons[buttonIndex].StartClickAnimation();
            yield return new WaitForSeconds(0.5f);
        }        
    }    
}
