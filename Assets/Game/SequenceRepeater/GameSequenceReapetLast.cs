using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceReapetLast : IGameSequenceRepeat
{    
    public override IEnumerator RepeatSequence(LinkedList<int> buttonSequence)
    {        
        yield return new WaitForSeconds(WaitTimeBeforeRepeat);
        LinkedListNode<int> temp = buttonSequence.Last;
        simonButtons[temp.Value].ClickAnimationAndSound();
        ExitState();
    }    
}
