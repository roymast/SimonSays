using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceReapetLast : IGameSequenceRepeat
{
    public override IEnumerator RepeatSequence(List<int> buttonSequence)
    {
        yield return new WaitForSeconds(1);
        simonButtons[buttonSequence.Count - 1].StartClickAnimation();
    }    
}
